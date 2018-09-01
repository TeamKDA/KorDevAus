#
# This sets the diagnostic settings on OMS workspace to given resource.
#

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName,
    [string] [Parameter(Mandatory=$true)] $ResourceType,
    [string] [Parameter(Mandatory=$true)] $ResourceName,
    [string] [Parameter(Mandatory=$true)] $WorkspaceResourceGroupName,
    [string] [Parameter(Mandatory=$true)] $WorkspaceResourceName,
    [bool] [Parameter(Mandatory=$false)] $Enabled = $true,
    [System.Collections.Generic.List`1[System.String]] [Parameter(Mandatory=$true)] $Categories,
    [bool] [Parameter(Mandatory=$false)] $RetentionEnabled = $true,
    [int] [Parameter(Mandatory=$false)] $RetentionInDays = 30
)

$resource =  Get-AzureRmResource `
    -ResourceGroupName $ResourceGroupName `
    -ResourceType $ResourceType `
    -ResourceName $ResourceName

$workspace = Get-AzureRmResource `
    -ResourceGroupName $WorkspaceResourceGroupName `
    -ResourceType Microsoft.OperationalInsights/workspaces `
    -ResourceName $WorkspaceResourceName

$diag = Set-AzureRmDiagnosticSetting `
            -ResourceId $resource.ResourceId `
            -WorkspaceId $workspace.ResourceId `
            -Enabled $Enabled `
            -Categories $Categories `
            -RetentionEnabled $RetentionEnabled `
            -RetentionInDays $RetentionInDays

Remove-Variable diag
Remove-Variable workspace
Remove-Variable resource
