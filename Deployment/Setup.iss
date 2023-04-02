; Installation settings
;   These settings are defaulted here and are not allowed to be set from the wizard installer
#ifndef AppMode
  #define AppMode "Debug" ;"Release", "Debug"
#endif

#define CoreLogLevel "Information" ; Can be customized from the command line
#define AppLogLevel "Information"; Can be customized from the command line

;   These are the allowed command line arguments
;     /EnableGrpc
;       Description: Enable a GRPC server that allows CRUD operations for scripts and the execution of them
;       Allowed values: "true"
;       Example: /EnableGrpc="true"
;
;     /EnableWeb
;       Description: Enables a Web Client to manage the scripts. Requires GRPC server to be enabled
;       Allowed values: "true"
;       Example: /EnableWeb="true"
;
;     /DarkMode
;       Description: Enables Dark Mode for the Desktop Client
;       Allowed values: "true"
;       Example: /DarkMode="true"
;
;     /DesktopIcon
;       Description: Creates a desktop shortcut
;       Allowed values: "true"
;       Example: /DesktopIcon="true"
;
;     /RunOnStartup
;       Description: Run the Desktop Client (server) on Windows Startup
;       Allowed values: "true"
;       Example: /RunOnStartup="true"
;
;     /CoreLogLevel
;       Description: Minimum logging level
;       Allowed values: "Verbose", "Debug", "Information", "Warning", "Error", "Fatal"
;       Example: /CoreLogLevel="Information"
;
;     /AppLogLevel
;       Description: Minimum logging level to display logs in the Desktop Client.
;       Allowed values: "Verbose", "Debug", "Information", "Warning", "Error", "Fatal"
;       Example: /AppLogLevel="Information"
;


; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
#if SameText(AppMode,"Release")
  #define AppName "CommonScripts"
#else
  #define AppName "CommonScripts_Debug"
#endif


#define AppPublisher "yeray697"
#define AppURL "https://github.com/yeray697/CommonScriptsContainer"
#define AppExeName "CommonScripts.exe"
#define AppFolder "..\Library\App\bin\" + AppMode + "\net6.0-windows"  
#define ApplicationVersion GetVersionNumbersString(AppFolder + "\" + AppExeName)

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{FCB9566C-9987-4095-805D-691FB98559E0}
AppName={#AppName}
AppVersion={#ApplicationVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
AllowNoIcons=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest           
OutputDir=.\Output
OutputBaseFilename={#AppName}_Installer_{#ApplicationVersion}
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[CustomMessages]
CoreSettings=Core settings:
OtherSettings=Other settings:
EnableGrpcSettings=Enable GRPC server
EnableWebClientSettings=Enable Web Client
DarkModeSettings=Enable Dark Mode for the desktop client
RunOnStartupSettings=Start application on Windows startup

[Tasks]
Name: "enableGrpc"; Description: "{cm:EnableGrpcSettings}"; GroupDescription: "{cm:CoreSettings}"; Flags: unchecked
Name: "enableWeb"; Description: "{cm:EnableWebClientSettings}"; GroupDescription: "{cm:CoreSettings}"; Flags: unchecked
Name: "darkMode"; Description: "{cm:DarkModeSettings}"; GroupDescription: "{cm:OtherSettings}"; Flags: unchecked
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:OtherSettings}"; Flags: unchecked
Name: "startup"; Description: "{cm:RunOnStartupSettings}"; GroupDescription: "{cm:OtherSettings}"; Flags: unchecked

[Files]
Source: "{#AppFolder}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}"
Name: "{group}\{cm:UninstallProgram,{#AppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; \
    ValueType: string; ValueName: "{#AppName}"; ValueData: "{app}\{#AppExeName} -hide -silent"; \
    Tasks: startup; Flags: uninsdeletevalue;

[Code]

function GetValueFromCommandLine(name: String) : String;
begin
  Result := ExpandConstant('{param:'+name+'}')
end;

function GetBooleanFromCommandLine(name: String) : Boolean;
begin
  Result := GetValueFromCommandLine(name) = 'true';
end;

procedure CurStepChanged(CurStep: TSetupStep);
var settings, enableGrpc, enableWeb, darkMode, coreLogLevel, appLogLevel : string;
begin  
  if CurStep = ssPostInstall then begin
    if GetBooleanFromCommandLine('EnableGrpc') or WizardIsTaskSelected('enableGrpc') then
       enableGrpc := 'true'
    else
       enableGrpc := 'false';

    if GetBooleanFromCommandLine('EnableWeb') or WizardIsTaskSelected('enableWeb') then
       enableWeb := 'true'
    else
       enableWeb := 'false';

    if GetBooleanFromCommandLine('DarkMode') or WizardIsTaskSelected('darkMode') then
       darkMode := 'true'
    else
       darkMode  := 'false';

    coreLogLevel := GetValueFromCommandLine('CoreLogLevel');
    if coreLogLevel = '' then
      coreLogLevel := '{#CoreLogLevel}';
      

    appLogLevel := GetValueFromCommandLine('AppLogLevel')
    if appLogLevel = '' then
      appLogLevel := '{#AppLogLevel}';

    settings := Format('{' #13#10 + \
'  "Core": {' #13#10 + \
'    "EnableGrpcServer": %s,' #13#10 + \
'    "EnableWebClient": %s,' #13#10 + \
'    "LoggingLevel": "%s"' #13#10 + \
'  },' #13#10 + \
'  "App": {' #13#10 + \
'    "DarkMode": %s,' #13#10 + \
'    "LoggingLevel": "%s"' #13#10 + \
'  }' #13#10 + \
'}', [enableGrpc, enableWeb, coreLogLevel, darkMode, appLogLevel]);
    SaveStringToFile(ExpandConstant('{app}') + '\settings.json', #13#10 + settings + #13#10, False);
  end
end;

[Run]
Filename: "{app}\{#AppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

