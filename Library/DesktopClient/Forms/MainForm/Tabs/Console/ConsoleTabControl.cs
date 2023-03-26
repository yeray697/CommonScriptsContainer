using DesktopClient.Extension;
using DesktopClient.Utils;
using Logging;
using Logging.Model;
using MaterialSkin;

namespace DesktopClient.Forms.MainForm.Tabs.Console
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
                LogLevel.Error or LogLevel.Fatal => ColorUtils.GetConsoleErrorForeColor(),
                LogLevel.Warning => ColorUtils.GetConsoleWarningForeColor(),
                _ => ColorUtils.GetConsoleDefaultForeColor(),
            };
            return color;
        }
        private void ReloadConsoleTextLines()
        {
            int lineCount = 0;
            Color color;
            foreach (string line in rtbConsole.Lines)
            {
                if (line.Contains(LogMessage.ERROR_STRING) || line.Contains(LogMessage.FATAL_STRING))
                    color = GetConsoleTextColor(LogLevel.Error);
                else if (line.Contains(LogMessage.WARNING_STRING))
                    color = GetConsoleTextColor(LogLevel.Warning);
                else
                    color = GetConsoleTextColor(LogLevel.Debug);

                rtbConsole.ColorLineThreadSafe(lineCount, line.Length, color);
                lineCount++;
            }
        }

        private void ThemeChanged(object sender)
        {
            ReloadConsoleTextLines();
        }
    }
}
