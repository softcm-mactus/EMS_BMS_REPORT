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

# update database config
Start-Process "SetupConfig/ReportsConfig.exe" -Wait

Import-Module WebAdministration 

# New-WebAppPool -name "MactusReportsPool"  -force

'creating IIS pool'
try
{
	$appPool = Get-WebAppPoolState -Name "MactusReportsPool" 2>$null
	if (!$appPool){
		$appPool = New-WebAppPool -Name "MactusReportsPool"  -force	
		$appPool.autoStart = "true"
		$appPool | Set-Item
	}
}
catch
{
	$appPool = New-WebAppPool -Name "MactusReportsPool"  -force	
	$appPool.autoStart = "true"
	$appPool | Set-Item
}

'creating website'
try
{
	md "c:\Web Sites" 2>$null
}
catch
{

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

try
{
	$isPathExist = Test-Path -Path "$webpath"
	if(($isPathExist -eq $true) -and !$force)
	{
		echo "$webpath already exists. Please delete the directory to install"
		exit(-1)
	}
	else
	{
		md $webpath 2>$null
	}
}
catch
{
	echo "error creating $webpath"
	exit(-1)
}
# All on one line
echo "Creating Website $name"
echo "Physical path = $webpath"
Copy-Item -Path "Web\*" -Destination "$webpath" -Recurse -Force
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

'copying applications'
try
{
	$isPathExist = Test-Path -Path "$installpath"
	if(($isPathExist -eq $true) -and !$force)
	{
		echo "$installpath already exists. Please delete the directory to install"
		exit(-1)
	}
	else
	{
		md $installpath 2>$null
	}
}
catch
{
	echo "error creating $installpath"
	exit(-1)
}

'starting website'
try{
	start-Website -name "$name"
}
catch
{
	'error starting website'
}

try
{
	Stop-Service -Name "$servicename"
}
catch
{
}

rd "$installpath\Client" 2>$null
rd "$installpath\Service" 2>$null
rd "$installpath\Service2" 2>$null
rd "$installpath\PingErrorApp" 2>$null
rd "$installpath\ExceptionReport" 2>$null
rd "$installpath\ServiceTest" 2>$null


md "$installpath\Client" 2>$null
md "$installpath\Service" 2>$null
md "$installpath\Service2" 2>$null
md "$installpath\PingErrorApp" 2>$null
md "$installpath\ExceptionReport" 2>$null
md "$installpath\ServiceTest" 2>$null

Copy-Item -Path "Client\*" -Destination "$installpath\Client" -Recurse -Force
Copy-Item -Path "Service\*" -Destination "$installpath\Service" -Recurse -Force
Copy-Item -Path "Service2\*" -Destination "$installpath\Service2" -Recurse -Force
Copy-Item -Path "PingErrorApp\*" -Destination "$installpath\PingErrorApp" -Recurse -Force
Copy-Item -Path "ExceptionReport\*" -Destination "$installpath\ExceptionReport" -Recurse -Force
Copy-Item -Path "ServiceTest\*" -Destination "$installpath\ServiceTest" -Recurse -Force

'installing service'
try{
	New-Service -Name "$servicename" -BinaryPathName "$installpath\Service\EmsBMSReportService.exe" 2>null
}
catch
{
	"Error installing Mactus EMS Reports Service"
}

Start-Service -Name "$servicename"

