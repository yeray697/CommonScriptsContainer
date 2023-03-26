using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DesktopClient.Utils
{
    public class DropShadow
    {
        #region Shadowing

        #region Structures

        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        #endregion

        #region Methods

        #region Public

        [DllImport("dwmapi.dll")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        #endregion

        #region Overrides

        public static void ApplyShadows(Form form)
        {
            var v = 2;

            _ = DwmSetWindowAttribute(form.Handle, 2, ref v, 4);

            var margins = new MARGINS()
            {
                bottomHeight = 1,
                leftWidth = 0,
                rightWidth = 0,
                topHeight = 0
            };

            _ = DwmExtendFrameIntoClientArea(form.Handle, ref margins);
        }

        #endregion

        #endregion

        #endregion
    }

}
