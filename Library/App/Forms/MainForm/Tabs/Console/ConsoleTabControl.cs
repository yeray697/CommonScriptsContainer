using App.Extension;
using App.Utils;
using Data;
using Logging;
using Logging.Model;
using MaterialSkin;

namespace App.Forms.MainForm.Tabs.Console
{
    public partial class ConsoleTabControl : UserControl
    {
        public ConsoleTabControl()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.ThemeChanged += ThemeChanged;
            LogManager.SetLogEmittedEventListener(LogEmitted);
        }
        private void LogEmitted(LogMessage log)
        {
            Color color = GetConsoleTextColor(log.Level);
            rtbConsole.AppendTextThreadSafe(log.ToString(), color, true);
        }
        private static Color GetConsoleTextColor(LogLevel logLevel)
        {
            var color = logLevel switch
            {
                LogLevel.Error or LogLevel.Fatal => ColorConstants.CONSOLE_ERROR_COLOR,
                LogLevel.Warning => ColorConstants.CONSOLE_WARNING_COLOR,
                _ => SettingsManager.Settings.App.DarkMode ? ColorConstants.CONSOLE_DEFAULT_DARK_COLOR : ColorConstants.CONSOLE_DEFAULT_LIGHT_COLOR,
            };
            return color;
        }
        private void ReloadConsoleTextLines()
        {
            int lineCount = 0;
            Color color = Color.White;
            bool changeLine = true;
            foreach (string line in rtbConsole.Lines)
            {
                if (line.Contains(LogMessage.ERROR_STRING) || line.Contains(LogMessage.FATAL_STRING))
                    color = ColorConstants.CONSOLE_ERROR_COLOR;
                else if (line.Contains(LogMessage.WARNING_STRING))
                    color = ColorConstants.CONSOLE_WARNING_COLOR;
                else
                    changeLine = false;

                if (changeLine)
                    rtbConsole.ColorLineThreadSafe(lineCount, line.Length, color);
                lineCount++;
                changeLine = true;
            }
        }

        private void ThemeChanged(object sender)
        {
            //ToDo
            //rtbConsole.ApplyTheme(_isDarkMode ? MetroSet_UI.Enums.Style.Dark : MetroSet_UI.Enums.Style.Light);
            ReloadConsoleTextLines();
        }
    }
}
