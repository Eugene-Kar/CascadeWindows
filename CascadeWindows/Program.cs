using System.Runtime.InteropServices;

namespace CascadeWindows;

static class Program
{
    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern IntPtr GetShellWindow();

    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    private const uint SWP_NOZORDER = 0x0004;
    private const int SW_RESTORE = 9;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        CascadeWindows();
    }

    private static void CascadeWindows()
    {
        List<IntPtr> windows = new List<IntPtr>();
        IntPtr shellWindow = GetShellWindow();

        // Enumerate all windows
        EnumWindows((hWnd, lParam) =>
        {
            // Filter to include only visible windows with a title that are not the shell window
            if (IsWindowVisible(hWnd) && GetParent(hWnd) == IntPtr.Zero && hWnd != shellWindow)
            {
                int length = GetWindowTextLength(hWnd);
                if (length > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(length + 1);
                    GetWindowText(hWnd, sb, sb.Capacity);
                    if (!string.IsNullOrWhiteSpace(sb.ToString()))
                    {
                        windows.Add(hWnd);
                    }
                }
            }
            return true;
        }, IntPtr.Zero);

        // Get screen work area
        Screen primaryScreen = Screen.PrimaryScreen!;
        Rectangle workingArea = primaryScreen.WorkingArea;

        // Calculate cascade parameters
        int offsetX = 30; // Horizontal offset for each cascaded window
        int offsetY = 30; // Vertical offset for each cascaded window
        int windowWidth = workingArea.Width * 3 / 4; // 75% of screen width
        int windowHeight = workingArea.Height * 3 / 4; // 75% of screen height

        // Cascade windows
        for (int i = 0; i < windows.Count; i++)
        {
            IntPtr hWnd = windows[i];
            
            // Restore if minimized
            if (IsIconic(hWnd))
            {
                ShowWindow(hWnd, SW_RESTORE);
            }

            // Calculate position
            int x = workingArea.Left + (i * offsetX) % (workingArea.Width - windowWidth);
            int y = workingArea.Top + (i * offsetY) % (workingArea.Height - windowHeight);

            // Set window position and size
            SetWindowPos(hWnd, IntPtr.Zero, x, y, windowWidth, windowHeight, SWP_NOZORDER);
        }
    }
}