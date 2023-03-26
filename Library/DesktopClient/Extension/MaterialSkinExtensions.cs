using DesktopClient.Utils;
using MaterialSkin;

namespace DesktopClient.Extension
{
    public static class MaterialSkinExtensions
    {
        public static void ChangeTheme(this MaterialSkinManager instance, bool isDarkMode, bool isFirstTime = false)
        {
            MaterialSkinManager.Themes newTheme = isDarkMode ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;

            if (!isFirstTime && newTheme == instance.Theme)
                return;
            instance.ColorScheme = ColorUtils.GetColorScheme();
            instance.Theme = newTheme;
        }
    }
}
