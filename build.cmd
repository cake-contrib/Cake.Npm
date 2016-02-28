@echo off

rem IF NOT EXIST "tools" (md "tools")
rem IF NOT EXIST "tools\addins" (md "tools\addins")
rem IF NOT DEFINED NUGET_EXE (
rem   SET NUGET_EXE=nuget.exe
rem )
rem %NUGET_EXE% install Cake -ExcludeVersion -OutputDirectory "tools"
rem call .\tools\Cake\Cake.exe .\build.cake %*

@echo off
cd %~dp0

SETLOCAL
powershell.exe -NoProfile -ExecutionPolicy unrestricted -Command "& { .\build.ps1 %*; if ($lastexitcode -ne 0) {write-host "ERROR: $lastexitcode" -fore RED; exit $lastexitcode} }" 