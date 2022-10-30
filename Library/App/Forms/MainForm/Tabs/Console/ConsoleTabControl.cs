using App.Extension;
using App.Utils;
using Logging;
using Logging.Model;
using MaterialSkin;
using Serilog.Events;

namespace App.Forms.MainForm.Tabs.Console
{
    public partial class ConsoleTabControl : UserControl
    {
        private bool _darkMode;
        public ConsoleTabControl()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.ThemeChanged += ThemeChanged;
            LogManager.GetConsoleSink().LogEmitted += LogEmitted;
        }
        private void LogEmitted(LogMessage log)
        {
            Color color = GetConsoleTextColor(log.Lvl);
            rtbConsole.AppendTextThreadSafe(log.ToString(), color, true);
        }
        private Color GetConsoleTextColor(LogEventLevel logLevel)
        {
            var color = logLevel switch
            {
                LogEventLevel.Error or LogEventLevel.Fatal => ColorConstants.CONSOLE_ERROR_COLOR,
                LogEventLevel.Warning => ColorConstants.CONSOLE_WARNING_COLOR,
                _ => _darkMode ? ColorConstants.CONSOLE_DEFAULT_DARK_COLOR : ColorConstants.CONSOLE_DEFAULT_LIGHT_COLOR,
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
