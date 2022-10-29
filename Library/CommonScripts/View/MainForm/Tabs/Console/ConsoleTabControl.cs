using CommonScripts.Extension;
using CommonScripts.Logging;
using CommonScripts.Settings;
using CommonScripts.Utils;
using MaterialSkin;
using Serilog.Events;
using System.Drawing;
using System.Windows.Forms;

namespace CommonScripts.View.MainForm.Tabs.Console
{
    public partial class ConsoleTabControl : UserControl
    {
        public ConsoleTabControl()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.ThemeChanged += ThemeChanged;
        }

        public void PrintLog(LogMessage log)
        {
            Color color = GetConsoleTextColor(log.Lvl);
            rtbConsole.AppendTextThreadSafe(log.ToString(), color, true);
        }
        private Color GetConsoleTextColor(LogEventLevel logLevel)
        {
            Color color;
            switch (logLevel)
            {
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    color = ColorUtils.CONSOLE_ERROR_COLOR;
                    break;
                case LogEventLevel.Warning:
                    color = ColorUtils.CONSOLE_WARNING_COLOR;
                    break;
                case LogEventLevel.Debug:
                case LogEventLevel.Verbose:
                default:
                    color = AppSettingsManager.IsDarkMode() ? ColorUtils.CONSOLE_DEFAULT_DARK_COLOR : ColorUtils.CONSOLE_DEFAULT_LIGHT_COLOR;
                    break;
            }
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
                    color = ColorUtils.CONSOLE_ERROR_COLOR;
                else if (line.Contains(LogMessage.WARNING_STRING))
                    color = ColorUtils.CONSOLE_WARNING_COLOR;
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
