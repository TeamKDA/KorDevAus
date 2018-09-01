#
# This sets the diagnostic settings on OMS workspace to given resource.
#

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceId,
    [string] [Parameter(Mandatory=$true)] $WorkspaceId,
    [bool] [Parameter(Mandatory=$false)] $Enabled = $true,
    [System.Collections.Generic.List`1[System.String]] [Parameter(Mandatory=$true)] $Categories,
    [bool] [Parameter(Mandatory=$false)] $RetentionEnabled = $true,
    [int] [Parameter(Mandatory=$false)] $RetentionInDays = 30
)

$diag = Set-AzureRmDiagnosticSetting `
            -ResourceId $ResourceId `
            -WorkspaceId $WorkspaceId `
            -Enabled $Enabled `
            -Categories $Categories `
            -RetentionEnabled $RetentionEnabled `
            -RetentionInDays $RetentionInDays

Remove-Variable diag
