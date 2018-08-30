param
(
    [Parameter(Mandatory=$false, HelpMessage="Enter Azure Subscription name. You need to be Subscription Admin to execute the script")]
    [string] $subscriptionName = "KDA - Sponsorship",

    [Parameter(Mandatory=$true, HelpMessage="Provide a name for the Service Principal")]
    [string] $servicePrincipalName = "spn-kda-dev-vstsowner",

    [Parameter(Mandatory=$false, HelpMessage="Provide a role assignment for Service Principal")]
    [string] $servicePrincipalRole = "owner"
)

#Initialize
$ErrorActionPreference = "Stop"
$VerbosePreference = "SilentlyContinue"
$pwGuid = [guid]::NewGuid()
$pwBytes = [System.Text.Encoding]::UTF8.GetBytes($pwGuid)
$password = [System.Convert]::ToBase64String($pwBytes)
$securePassword = ConvertTo-SecureString $password -AsPlainText -Force
$homePage = "https://" + $servicePrincipalName.replace(' ', '')
$identifierUri = $homePage


#Initialize subscription
$isAzureModulePresent = Get-Module -Name AzureRM* -ListAvailable
if ([String]::IsNullOrEmpty($isAzureModulePresent) -eq $true)
{
    Write-Output "Script requires AzureRM modules to be present. Obtain AzureRM from https://github.com/Azure/azure-powershell/releases. Please refer https://github.com/Microsoft/vsts-tasks/blob/master/Tasks/DeployAzureResourceGroup/README.md for recommended AzureRM versions." -Verbose
    return
}

Import-Module -Name AzureRM.Profile
Write-Output "Provide your credentials to access Azure subscription $subscriptionName" -Verbose
Login-AzureRmAccount -SubscriptionName $subscriptionName

$azureSubscription = Get-AzureRmSubscription -SubscriptionName $subscriptionName
$connectionName = $azureSubscription.SubscriptionName
$tenantId = $azureSubscription.TenantId
$id = $azureSubscription.SubscriptionId

#Create a new AD Application
Write-Output "Creating a new Application in AAD (App URI - $identifierUri)" -Verbose
$azureAdApplication = New-AzureRmADApplication -DisplayName $servicePrincipalName -HomePage $homePage -IdentifierUris $identifierUri -Password $securePassword -Verbose
$appId = $azureAdApplication.ApplicationId
Write-Output "Azure AAD Application creation completed successfully (Application Id: $appId)" -Verbose

#Create new SPN
Write-Output "Creating a new SPN" -Verbose
$spn = New-AzureRmADServicePrincipal -ApplicationId $appId
$objectId = $spn.Id
$spnName = $spn.ServicePrincipalNames[1]
Write-Output "SPN creation completed successfully (SPN Name: $spnName)" -Verbose

#Assign role to SPN
Write-Output "Waiting for SPN creation to reflect in Directory before Role assignment"
Start-Sleep 20
Write-Output "Assigning role ($servicePrincipalRole) to SPN App ($appId)" -Verbose
New-AzureRmRoleAssignment -RoleDefinitionName $servicePrincipalRole -ServicePrincipalName $appId
Write-Output "SPN role assignment completed successfully" -Verbose


#Print the values
Write-Output "`nCopy and Paste below values for Service Connection" -Verbose
Write-Output "***************************************************************************"
Write-Output "Subscription Name: $($azureSubscription.Name)"
Write-Output "Subscription Id: $($azureSubscription.Id)"
Write-Output "Tenant Id: $($azureSubscription.TenantId)"
Write-Output "Service Principal Application Id: $($azureAdApplication.ApplicationId)"
Write-Output "Service Principal Object Id: $($spn.Id)"
Write-Output "App Registration Object Id: $($azureAdApplication.ObjectId)"
Write-Output "Service Principal Key: $password"
Write-Output "Identifier URL: $identifierUri"
Write-Output "***************************************************************************"