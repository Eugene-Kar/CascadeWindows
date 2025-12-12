# CascadeWindows
Bringing back the Cascade Windows functionality that has been removed from current versions of Windows

## Overview
This utility adds a "Cascade Windows" option to the desktop context menu (right-click menu). When selected, it automatically cascades all open windows on your primary display, arranging them in an overlapping pattern similar to the classic Windows feature.

## Features
- **Desktop Context Menu Integration**: Right-click on the desktop to access "Cascade Windows"
- **Automatic Window Arrangement**: Cascades all visible, non-minimized windows
- **Smart Positioning**: Windows are arranged with proper offsets and sized appropriately for the screen
- **Minimized Window Handling**: Automatically restores minimized windows before cascading
- **Primary Display Focus**: All windows are cascaded on the primary monitor's working area

## Requirements
- Windows 10/11 (x64)
- .NET 8.0 Runtime (will be prompted to install if not present)

## Installation

### Using the MSI Installer (Recommended)
1. Download `CascadeWindowsSetup.msi` from the releases page
2. Run the installer and follow the prompts
3. Once installed, right-click on your desktop to see the new "Cascade Windows" option

### Building from Source
#### Prerequisites
- .NET 8.0 SDK or later
- WiX Toolset v6 (for building the installer)
- Windows OS (WiX only works on Windows)

#### Build Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/Eugene-Kar/CascadeWindows.git
   cd CascadeWindows
   ```

2. Build the application:
   ```bash
   dotnet build CascadeWindows/CascadeWindows.csproj -c Release
   ```

3. Publish the application for Windows x64:
   ```bash
   dotnet publish CascadeWindows/CascadeWindows.csproj -c Release -r win-x64 --self-contained false
   ```
   The executable will be located at: `CascadeWindows/bin/Release/net8.0-windows/win-x64/CascadeWindows.exe`

4. Build the installer (Windows only):
   ```bash
   dotnet build Installer/Installer.wixproj -c Release
   ```
   The MSI installer will be created in the `Installer/bin/Release` directory.

## Usage
1. Right-click anywhere on your desktop background
2. Click "Cascade Windows" from the context menu
3. All open windows will be automatically arranged in a cascading pattern

## How It Works
The application:
1. Enumerates all visible top-level windows using Win32 APIs
2. Filters out system windows and the Windows shell
3. Restores any minimized windows
4. Calculates optimal cascade positions based on screen dimensions
5. Resizes and positions each window with consistent offsets
6. Windows are sized to 75% of screen width and height
7. Each subsequent window is offset by 30 pixels horizontally and vertically

## Uninstallation
Use Windows Settings → Apps → Installed apps → Cascade Windows → Uninstall

Or use Control Panel → Programs → Uninstall a program

## Technical Details
- **Language**: C# (.NET 8.0)
- **UI Framework**: Windows Forms (minimal, no visible UI)
- **APIs Used**: Win32 User32.dll functions for window management
- **Installer**: WiX Toolset v6
- **Registry Entry**: `HKCR\Directory\Background\shell\CascadeWindows`

## License
MIT License - See [LICENSE](LICENSE) file for details

## Contributing
Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.

## Credits
This project recreates the classic "Cascade Windows" feature that was available in earlier versions of Windows but removed in Windows 10 and later versions.

