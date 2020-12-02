﻿using MetroSet_UI.Components;
using MetroSet_UI.Forms;

namespace CommonScripts.Extension
{
    public static class MetroStyleManagerExtensions
    {
        public static StyleManager Clone(this StyleManager styleManager, MetroSetForm form = null)
        {
            StyleManager newStyleManager = new StyleManager
            {
                CustomTheme = styleManager.CustomTheme
            };
            if (form != null) newStyleManager.MetroForm = form;
            newStyleManager.Style = styleManager.Style;
            newStyleManager.ThemeAuthor = styleManager.ThemeAuthor;
            newStyleManager.ThemeName = styleManager.ThemeName;

            return newStyleManager;
        }
    }
}
