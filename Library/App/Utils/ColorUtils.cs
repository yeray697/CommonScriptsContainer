using MaterialSkin;

namespace App.Utils
{
    public static class ColorUtils
    {
        private static readonly Color PRIMARY_COLOR = Color.FromArgb(0, 107, 95);
        private static readonly Color LIGHT_PRIMARY_COLOR = Color.FromArgb(68, 154, 140);
        private static readonly Color DARK_PRIMARY_COLOR = Color.FromArgb(0, 63, 53);
        private static readonly Color ACCENT_COLOR = Color.FromArgb(124, 153, 179);

        private static readonly Color CONSOLE_ERROR_DARK_COLOR = Color.FromArgb(246, 71, 71);
        private static readonly Color CONSOLE_ERROR_LIGHT_COLOR = Color.FromArgb(176, 0, 32);
        private static readonly Color CONSOLE_WARNING_DARK_COLOR = Color.Orange;
        private static readonly Color CONSOLE_WARNING_LIGHT_COLOR = Color.FromArgb(213, 136, 0);

        public static ColorScheme GetColorScheme()
            => new(PRIMARY_COLOR, DARK_PRIMARY_COLOR, LIGHT_PRIMARY_COLOR, ACCENT_COLOR, TextShade.WHITE);
        
        public static Color GetConsoleErrorForeColor()
            => IsDarkMode() ? CONSOLE_ERROR_DARK_COLOR : CONSOLE_ERROR_LIGHT_COLOR;

        public static Color GetConsoleWarningForeColor()
            => IsDarkMode() ? CONSOLE_WARNING_DARK_COLOR : CONSOLE_WARNING_LIGHT_COLOR;

        public static Color GetConsoleDefaultForeColor()
            => MaterialSkinManager.Instance.TextMediumEmphasisColor;

        private static bool IsDarkMode()
            => MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK;
    }
}
