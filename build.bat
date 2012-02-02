@echo off

:: Change to the directory that this batch file is in
:: NB: it must be invoked with a full path!
for /f %%i in ("%0") do set curpath=%%~dpi
cd /d %curpath%

:: Fetch input parameters
set target=%1
set build.version=%2
set build.config=release

:: Fallback to default settings for missing parameters
if "%target%"=="" set target=default

:: Execute the boo script with params - accessible with e.g. env("build.config")
lib\phantom\phantom.exe -f:build.boo %target% -a:build.config=%build.config% -a:build.output=%build.output% -a:build.version=%build.version%

if "%target%"=="nuget" (
   call resources\nuget pack nextra\nextra.csproj -prop configuration=release
   call resources\nuget pack nextra.web\nextra.web.csproj -prop configuration=release
   call resources\nuget pack nextra.mvc\nextra.mvc.csproj -prop configuration=release
   call resources\nuget pack nextra.wpf\nextra.wpf.csproj -prop configuration=release
   call resources\nuget pack nextra.webforms\nextra.webforms.csproj -prop configuration=release
   call resources\nuget pack nextra.winforms\nextra.winforms.csproj -prop configuration=release
   
   call resources\nuget push nextra.%build.version%.nupkg
   call resources\nuget push nextra.web."%build.version%".nupkg
   call resources\nuget push nextra.mvc.%build.version%.nupkg
   call resources\nuget push nextra.wpf.%build.version%.nupkg
   call resources\nuget push nextra.webforms.%build.version%.nupkg
   call resources\nuget push nextra.winforms.%build.version%.nupkg
   
   del nextra.%build.version%.nupkg
   del nextra.web."%build.version%".nupkg
   del nextra.mvc.%build.version%.nupkg
   del nextra.wpf.%build.version%.nupkg
   del nextra.webforms.%build.version%.nupkg
   del nextra.winforms.%build.version%.nupkg
)
   