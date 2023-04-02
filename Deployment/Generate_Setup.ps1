param([string]$appMode="Debug")
$msBuildPath = "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
$innoSetupPath = "C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
$tmpPath = ".\Setup.tmp.iss"
$setupPath = ".\Setup.iss" 

& $msBuildPath ..\Library\CommonScripts.sln /t:Rebuild /p:Configuration=$appMode /verbosity:quiet

"#define AppMode ""$appMode""`r`n" + (Get-Content $setupPath -Raw) | Set-Content $tmpPath

#& $innoSetupPath $tmpPath

Remove-Item $tmpPath