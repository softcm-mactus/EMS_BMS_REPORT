SetupConfig/ReportsConfig.exe
IF "%1" == "-force" (powershell.exe  -File "InstallReports.ps1" "-force") ELSE (powershell.exe  -File "InstallReports.ps1")
