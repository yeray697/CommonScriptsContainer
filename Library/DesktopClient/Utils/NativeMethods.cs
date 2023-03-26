using System.Runtime.InteropServices;

namespace DesktopClient.Utils
{
    public class NativeMethods
    {
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        
        private const int HWND_BROADCAST = 0xffff;

        public static void BringInstanceToForeground()
        {
            _ = SendMessage(
                (IntPtr)HWND_BROADCAST,
                WM_SHOWME,
                IntPtr.Zero,
                IntPtr.Zero);
        }

        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
    }
}
