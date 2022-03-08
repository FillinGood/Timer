using System.Runtime.InteropServices;

namespace Timer;
public static class Win32 {
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;
    public const int WM_HOTKEY = 0x0312;

    [DllImport("user32")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32")]
    public static extern bool ReleaseCapture();
    [DllImport("user32")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
    [DllImport("user32")]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    public enum ModifierKeys : uint {
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Win = 8
    }
}
