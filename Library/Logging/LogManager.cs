using Common;
using Contracts.Config;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Logging
{
    public static class LogManager
    {
        private const string LOG_FOLDER = @"logs";
        private const string LOG_FILE_NAME = @"CommonScripts.log";
        private const string QUARTZ_SERILOG = "Quartz";
        private const string MICROSOFT_SERILOG = "Microsoft";

        private static LoggingLevelSwitch? _levelSwitch;
        private static LogSink? _consoleLogSink;

        public static void InstanceLogger(Settings settings)
        {
            LogEventLevel fileMinLoggingLevel = ParseLogLevel(settings.Core.LoggingLevel);
            LogEventLevel consoleMinLoggingLevel = ParseLogLevel(settings.App.LoggingLevel);
            _consoleLogSink = new LogSink(consoleMinLoggingLevel);
            _levelSwitch = new LoggingLevelSwitch(fileMinLoggingLevel);

            string baseDirectory = FileUtils.GetConfigDirectory();
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
        public static void ChangeFileMinLoggingLevel(LogLevel newLogLevel)
        {
            if (_levelSwitch == null)
                throw new ArgumentNullException("Logger not instantiated. Call InstanceLogger() first", nameof(_levelSwitch));
            _levelSwitch.MinimumLevel = ParseLogLevel(newLogLevel);
        }
        public static void ChangeConsoleMinLoggingLevel(LogLevel newLogLevel)
        {
            if (_consoleLogSink == null)
                throw new ArgumentNullException("Logger not instantiated. Call InstanceLogger() first", nameof(_levelSwitch));
            _consoleLogSink.ChangeLoggingLevel(ParseLogLevel(newLogLevel));
        }
        public static void SetLogEmittedEventListener(LogSink.LogHandler action)
        {
            if (_consoleLogSink == null)
                throw new ArgumentNullException("Logger not instantiated. Call InstanceLogger() first", nameof(_levelSwitch));
            _consoleLogSink.LogEmitted += action;
        }
        private static void CreateLogDirectory(string baseDirectory)
        {
            if (!Directory.Exists(Path.Combine(baseDirectory, LOG_FOLDER)))
                Directory.CreateDirectory(Path.Combine(baseDirectory, LOG_FOLDER));
        }
        private static LogEventLevel ParseLogLevel(LogLevel logLevel)
            => (LogEventLevel)logLevel;
    }
}
