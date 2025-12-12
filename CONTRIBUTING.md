# Contributing to Cascade Windows

Thank you for your interest in contributing to Cascade Windows!

## Development Setup

### Prerequisites
- Windows 10/11 (for full development and testing)
- .NET 8.0 SDK or later
- Visual Studio 2022 or VS Code with C# extension (recommended)
- WiX Toolset v6 (for building the installer)

### Getting Started
1. Fork and clone the repository
2. Open `CascadeWindows.sln` in Visual Studio or your preferred IDE
3. Build the solution

### Building
You can use the provided build scripts:
- Windows: `build.bat`
- Linux/Mac: `build.sh` (builds app only, not installer)

Or use dotnet CLI directly:
```bash
# Build the application
dotnet build CascadeWindows/CascadeWindows.csproj -c Release

# Publish for Windows
dotnet publish CascadeWindows/CascadeWindows.csproj -c Release -r win-x64 --self-contained false

# Build the installer (Windows only)
dotnet build Installer/Installer.wixproj -c Release
```

### Testing
To test your changes:
1. Build the application
2. Run `CascadeWindows.exe` from the output directory
3. Open several windows on your desktop
4. Run the executable to see if windows cascade properly

To test the installer:
1. Build the installer (Windows only)
2. Install the MSI
3. Right-click on desktop to verify the context menu entry appears
4. Test the functionality via the context menu

### Code Style
- Follow standard C# coding conventions
- Use meaningful variable and method names
- Add comments for complex logic
- Keep methods focused and concise

### Submitting Changes
1. Create a feature branch from `main`
2. Make your changes
3. Test thoroughly
4. Create a pull request with a clear description of changes

### Areas for Contribution
- Additional window arrangement algorithms (tile, stack, etc.)
- Multi-monitor support
- Configuration options (window size, offset amounts)
- Keyboard shortcuts
- Localization/translations
- Bug fixes and performance improvements

## Questions?
Open an issue for any questions or suggestions!
