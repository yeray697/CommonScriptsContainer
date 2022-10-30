namespace App.Utils
{
    public static class ColorConstants
    {
        public static readonly Color LIGHT_FORE_COLOR = Color.FromArgb(20, 20, 20);
        public static readonly Color LIGHT_BACK_COLOR = Color.FromArgb(238, 238, 238);
        public static readonly Color DARK_FORE_COLOR = Color.FromArgb(204, 204, 204);
        public static readonly Color DARK_BACK_COLOR = Color.FromArgb(34, 34, 34);

        public static readonly Color CONSOLE_DEFAULT_DARK_COLOR = LIGHT_BACK_COLOR;
        public static readonly Color CONSOLE_DEFAULT_LIGHT_COLOR = LIGHT_FORE_COLOR;
        public static readonly Color CONSOLE_ERROR_COLOR = Color.FromArgb(176, 0, 32);
        public static readonly Color CONSOLE_WARNING_COLOR = Color.Orange;
    }
}
