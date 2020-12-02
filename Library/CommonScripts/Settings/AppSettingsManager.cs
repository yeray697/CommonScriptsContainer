using CommonScripts.Extension;
using CommonScripts.Model.Pojo;
using CommonScripts.Utils;
using Serilog.Events;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace CommonScripts.Settings
{
    public static class AppSettingsManager
    {
        private const string COMMON_SCRIPTS_FOLDER_NAME = "CommonScripts";
        private const string APP_CONFIG_NAME = "app.config";
        private const string APP_SETTINGS_SECTION = "appSettings";
        private const string SETTING_INSTALLATION_PATH = "installationPath";
        private const string SETTING_DO_NOT_ASK_RUN_STARTUP = "doNotAskAgainRunStartup";
        private const string SETTING_DARK_MODE = "isDarkMode";
        private const string SETTING_FILE_MIN_LOG_LEVEL = "fileMinimumLoggingLevel";
        private const string SETTING_CONSOLE_MIN_LOG_LEVEL = "consoleMinimumLoggingLevel";
        private const string FALSE_BOOL_STRING = "false";

        private static AppSettings _settings;

        #region Public Getters
        public static string GetProjectInstallationPath()
        {
            if (_settings != null)
                return _settings.InstallationPath;
            return GetSetting(SETTING_INSTALLATION_PATH).ToString();
        }
        public static bool AskToRunAppAtStartup()
        {
            if (_settings != null)
                return _settings.DoNotAskAgainRunStartup;
            return bool.Parse(GetSetting(SETTING_DO_NOT_ASK_RUN_STARTUP).ToString());
        }
        public static bool IsDarkMode()
        {
            if (_settings != null)
                return _settings.IsDarkMode;
            return bool.Parse(GetSetting(SETTING_DARK_MODE)?.ToString() ?? FALSE_BOOL_STRING);
        }
        public static LogEventLevel GetFileMinLogLevel()
        {
            if (_settings != null)
                return _settings.FileMinimumLoggingLevel;
            return EnumUtils.Parse<LogEventLevel>(GetSetting(SETTING_FILE_MIN_LOG_LEVEL));
        }
        public static LogEventLevel GetConsoleMinLogLevel()
        {
            if (_settings != null)
                return _settings.ConsoleMinimumLoggingLevel;
            return EnumUtils.Parse<LogEventLevel>(GetSetting(SETTING_CONSOLE_MIN_LOG_LEVEL));
        }
        #endregion
        #region Public Setters
        public static void SetInstallationPath(string installationPath)
        {
            SetSettingValue(SETTING_INSTALLATION_PATH, installationPath);
            _settings.InstallationPath = installationPath;
        }
        public static void SetAskToRunAppAtStartup(bool runAtStartup)
        {
            SetSettingValue(SETTING_DO_NOT_ASK_RUN_STARTUP, runAtStartup.ToString());
            _settings.DoNotAskAgainRunStartup = runAtStartup;
        }
        public static void SetIsDarkMode(bool isDarkMode)
        {
            SetSettingValue(SETTING_DARK_MODE, isDarkMode.ToString());
            _settings.IsDarkMode = isDarkMode;
        }
        public static void SetFileMinLogLevel(LogEventLevel minLogLevel)
        {
            SetSettingValue(SETTING_FILE_MIN_LOG_LEVEL, minLogLevel.NameToString());
            _settings.FileMinimumLoggingLevel = minLogLevel;
        }
        public static void SetConsoleMinLogLevel(LogEventLevel minLogLevel)
        {
            SetSettingValue(SETTING_CONSOLE_MIN_LOG_LEVEL, minLogLevel.NameToString());
            _settings.ConsoleMinimumLoggingLevel = minLogLevel;
        }
        #endregion
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
        public static bool AppConfigExists()
        {
            string appConfigDirectory = GetAppConfigDirectory();
            return Directory.Exists(appConfigDirectory) && File.Exists(Path.Combine(appConfigDirectory, APP_CONFIG_NAME));
        }
        public static void CreateAppConfig(string installationPath)
        {
            string appConfigDirectory = GetAppConfigDirectory();
            Directory.CreateDirectory(appConfigDirectory);
            File.WriteAllText(Path.Combine(appConfigDirectory, APP_CONFIG_NAME), GetAppConfigText(installationPath));
        }
        public static string GetAppConfigDirectory()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(folder, COMMON_SCRIPTS_FOLDER_NAME);
        }
        private static string GetAppConfigText(string installationPath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<configuration>");
            sb.AppendLine(" <appSettings>");
            sb.AppendLine("  <add key=\"" + SETTING_INSTALLATION_PATH + "\" value=\"" + installationPath + "\"/>");
            sb.AppendLine("  <add key=\"" + SETTING_DO_NOT_ASK_RUN_STARTUP + "\" value=\"false\"/>");
            sb.AppendLine("  <add key=\"" + SETTING_CONSOLE_MIN_LOG_LEVEL + "\" value=\"Information\"/>");
            sb.AppendLine("  <add key=\"" + SETTING_FILE_MIN_LOG_LEVEL + "\" value=\"Information\"/>");
            sb.AppendLine("  <add key=\"" + SETTING_DARK_MODE + "\" value=\"true\"/>");
            sb.AppendLine(" </appSettings>");
            sb.AppendLine("</configuration> ");

            return sb.ToString();
        }
        private static void SetSettingValue(string key, string value)
        {
            Configuration configuration = GetAppConfigFile();
            if (configuration.AppSettings.Settings[key] != null)
                configuration.AppSettings.Settings[key].Value = value;
            else
                configuration.AppSettings.Settings.Add(key, value);
            configuration.Save();

            ConfigurationManager.RefreshSection(APP_SETTINGS_SECTION);
        }
        private static object GetSetting(string key)
        {
            return GetAppConfigFile().AppSettings.Settings[key]?.Value;
        }
        private static Configuration GetAppConfigFile()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap { ExeConfigFilename = Path.Combine(GetAppConfigDirectory(), APP_CONFIG_NAME) };
            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }
    }
}
