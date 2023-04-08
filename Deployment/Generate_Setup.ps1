param([string]$appMode="Debug")

# Constants
$msBuildPath = "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
$innoSetupPath = "C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
$tmpPath = ".\Setup.tmp.iss"
$setupPath = ".\Setup.iss" 

# Build project
& $msBuildPath ..\Library\CommonScripts.sln /t:Rebuild /p:Configuration=$appMode /verbosity:quiet

# Generate Setup exe
"#define AppMode ""$appMode""`r`n" + (Get-Content $setupPath -Raw) | Set-Content $tmpPath
& $innoSetupPath $tmpPath

# Publish code
& $msBuildPath ..\Library\App\App.csproj /t:publish /p:PublishProfile=..\Library\App\Properties\PublishProfiles\ProjectBuild.pubxml /p:OutputPath=..\..\Deployment\Test


Remove-Item $tmpPath