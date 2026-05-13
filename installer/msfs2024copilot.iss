#define AppName "MSFS 2024 Copilot"
#define AppVersion "0.1.0"
#define AppPublisher "msfs2024copilot"
#define AppExeName "Msfs2024Copilot.exe"

[Setup]
AppId={{B9EAC7F4-8ED5-4D23-B413-52A4A9A94A8A}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={autopf}\{#AppName}
DisableDirPage=yes
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
OutputDir=output
OutputBaseFilename=Msfs2024CopilotSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Files]
Source: "..\src\Msfs2024Copilot\bin\Release\{#AppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\src\Msfs2024Copilot\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{autoprograms}\{#AppName}"; Filename: "{app}\{#AppExeName}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"; Flags: unchecked

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Launch {#AppName}"; Flags: nowait postinstall skipifsilent
