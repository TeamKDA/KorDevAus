#
# This adds/updates application settings blade to a given Azure Web App instance.
#

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName,
    [string] [Parameter(Mandatory=$true)] $WebAppName,
    [hashtable] [Parameter(Mandatory=$true)] $AppSettings,
    [hashtable] [Parameter(Mandatory=$false)] $SqlConnectionStrings = $null,
    [hashtable] [Parameter(Mandatory=$false)] $CustomConnectionStrings = $null
)

$webapp = Get-AzureRmWebApp -ResourceGroupName $ResourceGroupName -Name $WebAppName
$existingAppSettings = $webapp.SiteConfig.AppSettings
$existingConnectionStrings = $webapp.SiteConfig.ConnectionStrings

$newAppSettings = @{}
foreach($kvp in $existingAppSettings)
{
    $newAppSettings[$kvp.Name] = $kvp.Value
}

foreach($key in $AppSettings.Keys)
{
    $newAppSettings[$key] = $AppSettings[$key]
}

$newConnectionStrings = @{}
foreach($kvp in $existingConnectionStrings)
{
    $newConnectionStrings[$kvp.Name] = $kvp.Value
}

if ($SqlConnectionStrings -ne $null)
{
    foreach($key in $SqlConnectionStrings.Keys)
    {
        $newConnectionStrings[$key] = @{ Type = "SQLAzure"; Value = $SqlConnectionStrings[$key] }
    }
}

if ($CustomConnectionStrings -ne $null)
{
    foreach($key in $CustomConnectionStrings.Keys)
    {
        $newConnectionStrings[$key] = @{ Type = "Custom"; Value = $CustomConnectionStrings[$key] }
    }
}

if ($newConnectionStrings.Count -gt 0)
{
    Set-AzureRmWebApp `
        -ResourceGroupName $ResourceGroupName `
        -Name $WebAppName `
        -AppSettings $newAppSettings `
        -ConnectionStrings $newConnectionStrings
}
else
{
    Set-AzureRmWebApp `
        -ResourceGroupName $ResourceGroupName `
        -Name $WebAppName `
        -AppSettings $newAppSettings
}

Remove-Variable webapp
Remove-Variable existingAppSettings
Remove-Variable existingConnectionStrings
Remove-Variable newAppSettings
Remove-Variable newConnectionStrings
