#!/usr/bin/env bash
# Build script for Cascade Windows (cross-platform development)
# Note: Full installer build requires Windows

set -e

echo "Building Cascade Windows application..."
dotnet build CascadeWindows/CascadeWindows.csproj -c Release

echo "Publishing for Windows x64..."
dotnet publish CascadeWindows/CascadeWindows.csproj -c Release -r win-x64 --self-contained false

echo ""
echo "Build complete!"
echo "Executable: CascadeWindows/bin/Release/net8.0-windows/win-x64/CascadeWindows.exe"
echo ""
echo "Note: Installer build requires Windows OS."
echo "To build the installer on Windows, run:"
echo "  dotnet build Installer/Installer.wixproj -c Release"
echo ""
