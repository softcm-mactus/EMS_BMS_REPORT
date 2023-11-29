
rd "%1%\Client" 2>$null
rd "%1\Service" 2>$null
rd "%1\Service2" 2>$null
rd "%1\PingErrorApp" 2>$null
rd "%1\ExceptionReport" 2>$null
rd "%1\ServiceTest" 2>$null


md "%1\Client" 2>$null
md "%1\Service" 2>$null
md "%1\Service2" 2>$null
md "%1\PingErrorApp" 2>$null
md "%1\ExceptionReport" 2>$null
md "%1\ServiceTest" 2>$null

xcopy "Client\*" "%1%\Client\" /s /Y
xcopy "Service\*" "%1\Service\" /s /Y
xcopy "Service2\*" "%1\Service2\" /s /Y
xcopy "PingErrorApp\*" "%1\PingErrorApp\" /s /Y
xcopy "ExceptionReport\*" "%1\ExceptionReport\" /s /Y
xcopy "ServiceTest\*" "%1\ServiceTest\" /s /Y
xcopy "SetupConfig\*" "%1\SetupConfig\" /s /Y


md %2 2>$null
xcopy "Web\*" "%2\" /s /Y


