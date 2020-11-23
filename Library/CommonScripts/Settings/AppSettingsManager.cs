using CommonScripts.Extension;
using CommonScripts.Model.Pojo;
using CommonScripts.Utils;
using Serilog.Events;
using System.Configuration;

namespace CommonScripts.Settings
{
    public static class AppSettingsManager
    {
        private const string APP_CONFIG_NAME = "app.config";
        private static AppSettings _settings;
        private static Configuration GetAppConfigFile()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap { ExeConfigFilename = APP_CONFIG_NAME };
            return  ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        public static string GetProjectInstallationPath()
        {
            if (_settings != null)
                return _settings.InstallationPath;
            return GetSetting("installationPath").ToString();
        }
        public static bool AskToRunAppAtStartup()
        {
            if (_settings != null)
                return _settings.DoNotAskAgainRunStartup;
            return bool.Parse(GetSetting("doNotAskAgainRunStartup").ToString());
        }
        public static bool IsDarkMode()
        {
            if (_settings != null)
                return _settings.IsDarkMode;
            return bool.Parse(GetSetting("isDarkMode")?.ToString() ?? "false");
        }
        public static LogEventLevel GetFileMinLogLevel()
        {
            if (_settings != null)
                return _settings.FileMinimumLoggingLevel;
            return EnumUtils.Parse<LogEventLevel>(GetSetting("fileMinimumLoggingLevel"));
        }
        public static LogEventLevel GetConsoleMinLogLevel()
        {
            if (_settings != null)
                return _settings.ConsoleMinimumLoggingLevel;
            return EnumUtils.Parse<LogEventLevel>(GetSetting("consoleMinimumLoggingLevel"));
        }

        public static void SetInstallationPath(string installationPath)
        {
            SetSettingValue("installationPath", installationPath);
            _settings.InstallationPath = installationPath;
        }
        public static void SetAskToRunAppAtStartup(bool runAtStartup)
        {
            SetSettingValue("doNotAskAgainRunStartup", runAtStartup.ToString());
            _settings.DoNotAskAgainRunStartup = runAtStartup;
        }
        public static void SetIsDarkMode(bool isDarkMode)
        {
            SetSettingValue("isDarkMode", isDarkMode.ToString());
            _settings.IsDarkMode = isDarkMode;
        }
        public static void SetFileMinLogLevel(LogEventLevel minLogLevel)
        {
            SetSettingValue("fileMinimumLoggingLevel", minLogLevel.NameToString());
            _settings.FileMinimumLoggingLevel = minLogLevel;
        }
        public static void SetConsoleMinLogLevel(LogEventLevel minLogLevel)
        {
            SetSettingValue("consoleMinimumLoggingLevel", minLogLevel.NameToString());
            _settings.ConsoleMinimumLoggingLevel = minLogLevel;
        }

        private static void SetSettingValue(string key, string value)
        {
            Configuration configuration = GetAppConfigFile();
            if (configuration.AppSettings.Settings[key] != null)
                configuration.AppSettings.Settings[key].Value = value;
            else
                configuration.AppSettings.Settings.Add(key, value);
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
        private static object GetSetting(string key)
        {
            return GetAppConfigFile().AppSettings.Settings[key]?.Value;
        }

        public static void LoadSettings()
        {
            _settings = new AppSettings(GetProjectInstallationPath(), IsDarkMode(), AskToRunAppAtStartup(), GetConsoleMinLogLevel(), GetFileMinLogLevel());
        }
        public static AppSettings GetSettings()
        {
            if (_settings == null)
                LoadSettings();
            return _settings;
        }

        public static void SaveSettings(AppSettings settings)
        {
            SetAskToRunAppAtStartup(settings.DoNotAskAgainRunStartup);
            SetConsoleMinLogLevel(settings.ConsoleMinimumLoggingLevel);
            SetFileMinLogLevel(settings.FileMinimumLoggingLevel);
            SetInstallationPath(settings.InstallationPath);
            SetIsDarkMode(settings.IsDarkMode);
        }
    }
}
