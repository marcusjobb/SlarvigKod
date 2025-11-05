@echo off
REM run-sonar.cmd - automates Sonar begin/build/end for this repo
REM Usage: run-sonar.cmd [SONAR_TOKEN]
REM or set environment variable SONAR_TOKEN and run without args.

setlocal enabledelayedexpansion

set SOLUTION_FILE=SlarvigKod.sln
set PROJECT_FILE=SlarvigKod.csproj
set SONAR_ORG=marcusjobb
set SONAR_KEY=marcusjobb_slarvigkod
set SKIP_JRE_PROVISIONING=false
set VERBOSE=false

if "%~1"=="" (
 if "%SONAR_TOKEN%"=="" (
 echo Error: SONAR token not provided as argument or SONAR_TOKEN env var.
 echo Usage: %~nx0 [SONAR_TOKEN]
 exit /b1
 )
) else (
 set SONAR_TOKEN=%~1
)

echo Using Sonar token: ***** (hidden)
echo Solution: %SOLUTION_FILE%
echo Project: %PROJECT_FILE%

if not exist "%SOLUTION_FILE%" (
 echo Solution not found. Creating %SOLUTION_FILE%...
 dotnet new sln -n SlarvigKod || exit /b1
)

REM Ensure project is in solution
REM Use correct 'list' command and pipe to findstr. Redirect only findstr output to nul.
dotnet sln "%SOLUTION_FILE%" list | findstr /I /C:"%PROJECT_FILE%" >nul
if errorlevel 1 (
 echo Adding %PROJECT_FILE% to solution...
 dotnet sln "%SOLUTION_FILE%" add "%PROJECT_FILE%" || exit /b1
) else (
 echo Project already in solution.
)

set SKIP_JRE_FLAG=
if /I "%SKIP_JRE_PROVISIONING%"=="true" set SKIP_JRE_FLAG=/d:sonar.scanner.skipJreProvisioning=true

set VERBOSE_FLAG=
if /I "%VERBOSE%"=="true" set VERBOSE_FLAG=/d:sonar.verbose=true

echo Starting Sonar begin...
dotnet sonarscanner begin /k:"%SONAR_KEY%" /o:"%SONAR_ORG%" /d:sonar.login="%SONAR_TOKEN%" %SKIP_JRE_FLAG% %VERBOSE_FLAG% || (
 echo Sonar begin failed.
 exit /b1
)

echo Building solution...
dotnet build "%SOLUTION_FILE%" || (
 echo Build failed.
 echo You must run build between begin and end.
 dotnet sonarscanner end /d:sonar.login="%SONAR_TOKEN%"
 exit /b1
)

echo Finishing Sonar end...
dotnet sonarscanner end /d:sonar.login="%SONAR_TOKEN%" %VERBOSE_FLAG% || (
 echo Sonar end failed.
 exit /b1
)

echo Sonar analysis completed successfully.
endlocal
exit /b0
