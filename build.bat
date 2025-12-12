@echo off
REM Build script for Cascade Windows

echo Building Cascade Windows application...
dotnet build CascadeWindows/CascadeWindows.csproj -c Release

if %ERRORLEVEL% NEQ 0 (
    echo Build failed!
    exit /b %ERRORLEVEL%
)

echo Publishing for Windows x64...
dotnet publish CascadeWindows/CascadeWindows.csproj -c Release -r win-x64 --self-contained false

if %ERRORLEVEL% NEQ 0 (
    echo Publish failed!
    exit /b %ERRORLEVEL%
)

echo Building installer...
dotnet build Installer/Installer.wixproj -c Release

if %ERRORLEVEL% NEQ 0 (
    echo Installer build failed!
    exit /b %ERRORLEVEL%
)

echo.
echo Build complete!
echo Executable: CascadeWindows\bin\Release\net8.0-windows\win-x64\CascadeWindows.exe
echo Installer: Installer\bin\x64\Release\CascadeWindowsSetup.msi
echo.
