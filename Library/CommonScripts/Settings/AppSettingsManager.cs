using System.Configuration;

namespace CommonScripts.Settings
{
    public static class AppSettingsManager
    {
        private const string APP_CONFIG_NAME = "app.config";
        private static Configuration GetAppConfigFile()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap { ExeConfigFilename = APP_CONFIG_NAME };
            return  ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        private static object GetSetting(string key)
        {
            return GetAppConfigFile().AppSettings.Settings[key].Value;
        }
        public static string GetProjectInstallationPath()
        {
            return GetSetting("installationPath").ToString();
        }

        public static bool AskToRunAppAtStartup()
        {
            return bool.Parse(GetSetting("doNotAskAgainRunStartup").ToString());
        }

        public static void SetAskToRunAppAtStartup(bool runAtStartup)
        {
            SetSettingValue("doNotAskAgainRunStartup", runAtStartup.ToString());
        }

        private static void SetSettingValue(string key, string value)
        {
            Configuration configuration = GetAppConfigFile();
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
