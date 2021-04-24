using CommonScripts.Settings;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.IO;

namespace CommonScripts.Logging
{
    public static class LogManager
    {
        private const string LOG_FOLDER = @"logs";
        private const string LOG_FILE_NAME = @"CommonScripts.log";
        private const string QUARTZ_SERILOG = "Quartz";
        private const string MICROSOFT_SERILOG = "Microsoft";
        private static LoggingLevelSwitch _levelSwitch;
        private static LogSink _consoleLogSink;
        public static void InstanceLogger()
        {
            _consoleLogSink = new LogSink();
            _levelSwitch = new LoggingLevelSwitch(AppSettingsManager.GetFileMinLogLevel());
            string baseDirectory = AppSettingsManager.GetAppConfigDirectory();
            CreateLogDirectory(baseDirectory);
            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(_levelSwitch)
                .MinimumLevel.Override(QUARTZ_SERILOG, LogEventLevel.Warning)
                .MinimumLevel.Override(MICROSOFT_SERILOG, LogEventLevel.Warning);

            loggerConfiguration
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(baseDirectory, LOG_FOLDER, LOG_FILE_NAME))
                .WriteTo.Sink(_consoleLogSink);

            Log.Logger = loggerConfiguration.CreateLogger();
        }
        private static void CreateLogDirectory(string baseDirectory)
        {
            if (!Directory.Exists(Path.Combine(baseDirectory, LOG_FOLDER)))
                Directory.CreateDirectory(Path.Combine(baseDirectory, LOG_FOLDER));
        }
        public static void ChangeMinLoggingLevel(LogEventLevel newLogLevel)
        {
            _levelSwitch.MinimumLevel = newLogLevel;
        }
        internal static LogSink GetConsoleSink()
        {
            return _consoleLogSink;
        }
    }
}
