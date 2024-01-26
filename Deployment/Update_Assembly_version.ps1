param([string]$newVersion = "3.1.2")
function Update-AssemblyVersion
{
    param
    (
      [Parameter(Mandatory,ValueFromPipeline)]
      [string]
      $XmlPath,
      
      [string]
      $Version = 0
    )

    Write-Host "Updating Version for $XmlPath"
    $xml = New-Object XML
    $xml.Load($XmlPath)
    $element =  $xml.SelectSingleNode("//AssemblyVersion")
    $element.InnerText = $Version
    $xml.Save($XmlPath)
}

$projects = @("App", "Common", "Contracts", "Data", "DesktopClient", "JobManager", "Logging");

$projects | ForEach-Object {
   "$PSScriptRoot\..\Library\$_\$_.csproj" | Update-AssemblyVersion -Version $newVersion
 }