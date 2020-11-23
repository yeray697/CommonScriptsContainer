using Serilog.Events;
using System;

namespace CommonScripts.Model.Pojo
{
    public class AppSettings : ICloneable
    {
        public AppSettings(string installationPath, bool isDarkMode, bool doNotAskAgainRunStartup, LogEventLevel consoleMinLogLevel, LogEventLevel fileMinLogLevel)
        {
            this.InstallationPath = installationPath;
            this.IsDarkMode = isDarkMode;
            this.DoNotAskAgainRunStartup = doNotAskAgainRunStartup;
            this.ConsoleMinimumLoggingLevel = consoleMinLogLevel;
            this.FileMinimumLoggingLevel = fileMinLogLevel;
        }

        public bool IsDarkMode { get; set; }
        public string InstallationPath { get; set; }
        public bool DoNotAskAgainRunStartup { get; set; }
        public LogEventLevel FileMinimumLoggingLevel { get; set; }
        public LogEventLevel ConsoleMinimumLoggingLevel { get; set; }

        public object Clone()
        {
            return new AppSettings(this.InstallationPath, this.IsDarkMode, this.DoNotAskAgainRunStartup, this.ConsoleMinimumLoggingLevel, this.FileMinimumLoggingLevel);
        }
    }
}
