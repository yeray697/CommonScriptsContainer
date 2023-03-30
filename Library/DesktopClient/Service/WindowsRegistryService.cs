using DesktopClient.Service.Interfaces;
using Data;
using Microsoft.Win32;
using Serilog;

namespace DesktopClient.Service
{
    public class WindowsRegistryService : IWindowsRegistryService
    {
        private const string WINDOWS_REGISTRY_STARTUP_PATH = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
        private const string WINDOWS_REGISTRY_STARTUP_KEY = "CommonScripts";
        private const string APP_EXE_NAME = "CommonScripts.Exe";
        public const string APP_HIDE_ARG = "-hide";
        public const string APP_ON_STARTUP_ARG = "-startup";

        public bool IsAppSetToRunAtStartup()
        {
            var key = Registry.GetValue(WINDOWS_REGISTRY_STARTUP_PATH,
             WINDOWS_REGISTRY_STARTUP_KEY
             , null);
            return key != null;
        }
        public bool SetAppToRunAtStartup()
        {
            string exePath = Path.Combine(SettingsManager.Settings.Core.InstallationPath, APP_EXE_NAME);
            bool result = true;
            try
            {
                Registry.SetValue(WINDOWS_REGISTRY_STARTUP_PATH,
                 WINDOWS_REGISTRY_STARTUP_KEY,
                 $"{exePath} {APP_HIDE_ARG} {APP_ON_STARTUP_ARG}");
            }
            catch (Exception e)
            {
                Log.Error(e, "Error while saving the windows registry.");
                result = false;
            }

            return result;
        }
    }
}
