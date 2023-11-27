set msbuild="%ProgramFiles%\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\msbuild.exe"
%msbuild% EmsBMSReports.sln /p:DeployOnBuild=true /p:PublishProfile=Release /p:Configuration=Release /t:Rebuild
rmdir InstallPackages /s /q
mkdir InstallPackages
xcopy EmsBMSReports\bin\Release\ InstallPackages\Client\ /s
xcopy EmsBMSReportService\bin\Release\ InstallPackages\Service\ /s
xcopy EmsBMSReportService2\bin\Release\ InstallPackages\Service2\ /s
xcopy EMSBMSReportServiceTest\bin\Release\ InstallPackages\ServiceTest\ /s
xcopy MactusReportWeb\bin\app.publish\ InstallPackages\Web\ /s
xcopy PingErrorApp\bin\Release\ InstallPackages\PingErrorApp\ /s
xcopy ExceptionReport\bin\Release\ InstallPackages\ExceptionReport\ /s
xcopy ReportsConfig\bin\Release\ InstallPackages\SetupConfig\ /s
copy InstallScripts\InstallIIS.ps1 InstallPackages\InstallIIS.ps1
copy InstallScripts\InstallReports.ps1 InstallPackages\InstallReports.ps1
copy InstallScripts\UpgradeReports.ps1 InstallPackages\UpgradeReports.ps1
copy InstallScripts\install.bat InstallPackages\install.bat
copy InstallScripts\upgrade.bat InstallPackages\upgrade.bat

