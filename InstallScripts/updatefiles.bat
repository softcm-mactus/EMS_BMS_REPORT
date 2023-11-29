
copy /Y "%2\images\ReportLogo.png" "Web\images\ReportLogo.png" 2>null
copy /Y "%2\Web.config" "Web\Web.config" 2>null

copy /Y "%1\Client\EmsBMSReports.exe.config" "Client\EmsBMSReports.exe.config" 2>null
copy /Y "%1\Service\EmsBMSReportService.exe.config" "Service\EmsBMSReportService.exe.config" 2>null
copy /Y "%1\Service2\EmsBMSReportService2.exe.config" "Service2\EmsBMSReportService2.exe.config" 2>null
copy /Y "%1\ServiceTest\EMSBMSReportServiceTest.exe.config" "ServiceTest\EMSBMSReportServiceTest.exe.config" 2>null
copy /Y "%1\ExceptionReport\ExceptionReport.exe.config" "ExceptionReport\ExceptionReport.exe.config" 2>null
copy /Y "%1\PingErrorApp\PingErrorApp.exe.config" "PingErrorApp\PingErrorApp.exe.config" 2>null
copy /Y "%1\PingErrorApp\iplist.txt" "PingErrorApp\iplist.txt" 2>null


xcopy "Client\*" "%1%\Client\" /s /Y 2>null
xcopy "Service\*" "%1\Service\" /s /Y 2>null
xcopy "Service2\*" "%1\Service2\" /s /Y 2>null
xcopy "PingErrorApp\*" "%1\PingErrorApp\" /s /Y 2>null
xcopy "ExceptionReport\*" "%1\ExceptionReport\" /s /Y 2>null
xcopy "ServiceTest\*" "%1\ServiceTest\" /s /Y 2>null
xcopy "SetupConfig\*" "%1\SetupConfig\" /s /Y 2>null

xcopy "Web\*" "%2\" /s /Y 2>null


