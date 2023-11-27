param([switch]$force, [switch]$Elevated, [string]$cwd)

if($force)
{
	'Forcing installation'
}

if(!$cwd)
{
	$cwd = Get-Location
}

function Test-Admin {
    $currentUser = New-Object Security.Principal.WindowsPrincipal $([Security.Principal.WindowsIdentity]::GetCurrent())
    $currentUser.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)
}

if ((Test-Admin) -eq $false)  {
    if ($elevated) {
        # tried to elevate, did not work, aborting
    } else {
		"Current Directory - $cwd"
		if($force)
        {
			Start-Process powershell.exe -Verb RunAs -WorkingDirectory $cwd -ArgumentList ('-noexit -file "{0}" -elevated -force -cwd "{1}"' -f ($myinvocation.MyCommand.Definition,$cwd))
		}
		else
		{
			Start-Process powershell.exe -Verb RunAs -WorkingDirectory $cwd -ArgumentList ('-noexit -file "{0}" -elevated -cwd "{1}"' -f ($myinvocation.MyCommand.Definition,$cwd))
		}
    }
    exit
}

'running with full privileges'

'starting Installation'
$name="MactusReports"
$servicename = "Mactus EMS Reports"
$port="105"
$webpath = "c:\WebSites\$name"
$installpath = "d:\Mactus\Reports"

"Current Directory - $cwd"
Set-Location $cwd

try
{
	$isPathExist = Test-Path -Path "$webpath"
	if($isPathExist -eq $true)
	{
	}
	else
	{
		echo "$webpath does not exists. Please install the reports"
		exit(-1)
	}
}
catch
{
	echo "error accessing $webpath"
	exit(-1)
}

try
{
	$site = get-WebSite -name "$name"
	if($site -and !$force)
	{
		'website already exists. stopping website'
		stop-WebSite -name "$name"
	}
}
catch
{
}

# All on one line
Copy-Item -Path "$webpath\images\ReportLogo.png" -Destination "Web\images\ReportLogo.png" -Force
Copy-Item -Path "$webpath\Web.config" -Destination "Web\Web.config" -Force 
xcopy "Web\*" "$webpath\" /s /Y

try
{
	$site = get-WebSite -name "$name"
	if(!$site)
	{
		$site = new-WebSite -name "$name" -PhysicalPath "$webpath" -Port "$port" -force
	}
}
catch
{
	$site = new-WebSite -name "$name" -PhysicalPath "$webpath" -Port "$port" -force
}

Start-WebSite  -name "$name"

try
{
	Stop-Service -Name "$servicename"
}
catch
{
	"error stopping service $servicename"
}

try
{
	$isPathExist = Test-Path -Path "$installpath"
	if(($isPathExist -eq $true) -and !$force)
	{
	}
	else
	{
		echo "$installpath does not exists. Please use InstallReports.ps1"
		exit(-1)
	}
}
catch
{
	echo "error creating $installpath"
	exit(-1)
}


md "$installpath\Client" 2>$null
md "$installpath\Service"  2>$null
md "$installpath\Service2"  2>$null
md "$installpath\PingErrorApp"  2>$null
md "$installpath\ExceptionReport"  2>$null
md "$installpath\ServiceTest"  2>$null

Copy-Item -Path "$installpath\Client\EmsBMSReports.exe.config" -Destination "Client\EmsBMSReports.exe.config" -Force
Copy-Item -Path "$installpath\Service\EmsBMSReportService.exe.config" -Destination "Service\EmsBMSReportService.exe.config"  -Force
Copy-Item -Path "$installpath\Service2\EmsBMSReportService2.exe.config" -Destination "Service2\EmsBMSReportService2.exe.config" -Force
Copy-Item -Path "$installpath\ServiceTest\EMSBMSReportServiceTest.exe.config" -Destination "ServiceTest\EMSBMSReportServiceTest.exe.config" -Force
Copy-Item -Path "$installpath\ExceptionReport\ExceptionReport.exe.config" -Destination "ExceptionReport\ExceptionReport.exe.config" -Force
Copy-Item -Path "$installpath\PingErrorApp\PingErrorApp.exe.config" -Destination "PingErrorApp\PingErrorApp.exe.config" -Force
Copy-Item -Path "$installpath\PingErrorApp\iplist.txt" -Destination "PingErrorApp\iplist.txt" 2>$null

xcopy "Client\*" "$installpath\Client\" /s /Y
xcopy "Service\*" "$installpath\Service\" /s /Y
xcopy "Service2\*" "$installpath\Service2\" /s /Y
xcopy "PingErrorApp\*" "$installpath\PingErrorApp\" /s /Y
xcopy "ExceptionReport\*" "$installpath\ExceptionReport\" /s /Y
xcopy "ServiceTest\*" "$installpath\ServiceTest\" /s /Y
xcopy "SetupConfig\*" "$installpath\SetupConfig\" /s /Y

Copy-Item -Path "Service\*" -Destination "$installpath\Service" -Recurse -Force
Copy-Item -Path "Service2\*" -Destination "$installpath\Service2" -Recurse -Force
Copy-Item -Path "PingErrorApp\*" -Destination "$installpath\PingErrorApp" -Recurse -Force
Copy-Item -Path "ExceptionReport\*" -Destination "$installpath\ExceptionReport" -Recurse -Force
Copy-Item -Path "ServiceTest\*" -Destination "$installpath\ServiceTest" -Recurse -Force

Start-Service -Name "$servicename"
