Param(
    [string]$Script = "build.cake",
    [string]$Target = "Default",
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",
    [ValidateSet("Quiet", "Minimal", "Normal", "Verbose", "Diagnostic")]
    [string]$Verbosity = "Normal",
    [switch]$Experimental,
    [switch]$WhatIf
)

# $PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

$TOOLS_DIR = Join-Path $PSScriptRoot "tools"
$NUGET_EXE = Join-Path $TOOLS_DIR "nuget.exe"
$CAKE_EXE = Join-Path $TOOLS_DIR "Cake/Cake.exe"

if (!(Test-Path $TOOLS_DIR)) {
    New-Item -Path $TOOLS_DIR -Type Directory
}

# Should we use experimental build of Roslyn?
$UseExperimental = "";
if($Experimental.IsPresent) {
    $UseExperimental = "-experimental"
}

# Is this a dry run?
$UseDryRun = "";
if($WhatIf.IsPresent) {
    $UseDryRun = "-dryrun"
}

# Try download NuGet.exe if do not exist.
if (!(Test-Path $NUGET_EXE)) {
    Invoke-WebRequest -Uri http://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile $NUGET_EXE
}

# Make sure NuGet exists where we expect it.
if (!(Test-Path $NUGET_EXE)) {
    Throw "Could not find NuGet.exe"
}

# Invoke-Expression "$NUGET_EXE install Cake -ExcludeVersion -OutputDirectory $TOOLS_DIR"
Push-Location $TOOLS_DIR
Invoke-Expression "$NUGET_EXE install -ExcludeVersion -OutputDirectory $TOOLS_DIR"
Pop-Location
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

# Make sure that Cake has been installed.
if (!(Test-Path $CAKE_EXE)) {
	Write-Host $CAKE_EXE
    Throw "Could not find Cake.exe"
}

# Start Cake
Invoke-Expression "$CAKE_EXE `"$Script`" -target=`"$Target`" -configuration=`"$Configuration`" -verbosity=`"$Verbosity`" $UseDryRun $UseExperimental"
Write-Host
exit $LASTEXITCODE