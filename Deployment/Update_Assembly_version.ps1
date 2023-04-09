param([string]$newVersion)
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

    $xml = New-Object XML
    $xml.Load($XmlPath)
    $element =  $xml.SelectSingleNode("//AssemblyVersion")
    $element.InnerText = $Version
    $xml.Save($XmlPath)
}

".\Library\App\App.csproj"                      | Update-AssemblyVersion -Version $newVersion
".\Library\Common\Common.csproj"                | Update-AssemblyVersion -Version $newVersion
".\Library\Contracts\Contracts.csproj"          | Update-AssemblyVersion -Version $newVersion
".\Library\Data\Data.csproj"                    | Update-AssemblyVersion -Version $newVersion
".\Library\DesktopClient\DesktopClient.csproj"  | Update-AssemblyVersion -Version $newVersion
".\Library\JobManager\JobManager.csproj"        | Update-AssemblyVersion -Version $newVersion
".\Library\Logging\Logging.csproj"              | Update-AssemblyVersion -Version $newVersion