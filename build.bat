@echo off

:: Change to the directory that this batch file is in
:: NB: it must be invoked with a full path!
for /f %%i in ("%0") do set curpath=%%~dpi
cd /d %curpath%

:: Fetch input parameters
set target=%1
::set build.config=%2		Adjustable build config is more suited for sites and applications
::set build.output=%3
set build.output=%2

:: Fallback to default settings for missing parameters
if "%target%"=="" set target=default
if "%build.config%"=="" set build.config=release
if "%build.output%"=="" set build.output=output

:: Execute the boo script with params - accessible with e.g. env("build.config")
lib\phantom\phantom.exe -f:build.boo %target% -a:build.config=%build.config% -a:build.output=%build.output%