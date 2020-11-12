using System.Configuration;

namespace CommonScripts.Settings
{
    public static class AppSettingsManager
    {
        public static string GetProjectInstallationPath()
        {
            return ConfigurationManager.AppSettings["installationPath"];
        }

        public static bool AskToRunAppAtStartup()
        {
            return bool.Parse(ConfigurationManager.AppSettings["doNotAskAgainRunStartup"]);
        }

        public static void SetAskToRunAppAtStartup(bool runAtStartup)
        {
            SetSettingValue("doNotAskAgainRunStartup", runAtStartup.ToString());
        }

        private static void SetSettingValue(string key, string value)
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap { ExeConfigFilename = "app.config" };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
