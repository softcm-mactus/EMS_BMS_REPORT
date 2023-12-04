set msbuild="%ProgramFiles%\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\msbuild.exe"
%msbuild% EmsBMSReports.sln /p:DeployOnBuild=true /p:PublishProfile=Release /p:Configuration=Release /t:clean /property:Platform=x64
%msbuild% EmsBMSReports.sln /p:DeployOnBuild=true /p:PublishProfile=Release /p:Configuration=Release /t:Rebuild /property:Platform=x64
rmdir InstallPackages /s /q
mkdir InstallPackages
xcopy EmsBMSReports\bin\x64\Release\ InstallPackages\Client\ /s
xcopy EmsBMSReportService\bin\x64\Release\ InstallPackages\Service\ /s
xcopy EmsBMSReportService2\bin\x64\Release\ InstallPackages\Service2\ /s
xcopy EMSBMSReportServiceTest\bin\x64\Release\ InstallPackages\ServiceTest\ /s
xcopy MactusReportWeb\bin\app.publish\ InstallPackages\Web\ /s
xcopy PingErrorApp\bin\x64\Release\ InstallPackages\PingErrorApp\ /s
xcopy ExceptionReport\bin\x64\Release\ InstallPackages\ExceptionReport\ /s
xcopy ReportsConfig\bin\x64\Release\ InstallPackages\Setup\ /s
xcopy InstallScripts\ InstallPackages\Setup\ /s
