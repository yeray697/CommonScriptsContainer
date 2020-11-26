using CommonScripts.Utils;
using MetroSet_UI.Enums;
using System.Windows.Forms;

namespace CommonScripts.Extension
{
    public static class FormControlsExtensions
    {
        public static void ApplyTheme(this Control c, Style style)
        {
			switch (style)
			{
				case Style.Light:
					c.ForeColor = ColorUtils.LIGHT_FORE_COLOR;
					c.BackColor = ColorUtils.LIGHT_BACK_COLOR;
					break;

				case Style.Dark:
					c.ForeColor = ColorUtils.DARK_FORE_COLOR;
					c.BackColor = ColorUtils.DARK_BACK_COLOR;
					break;
			}
			c.Invalidate();
		}
    }
}
