using Common;
using DesktopClient.Service.Interfaces;
using Microsoft.Win32;
using Serilog;

namespace DesktopClient.Service
{
    public class WindowsRegistryService : IWindowsRegistryService
    {
        private const string WINDOWS_REGISTRY_STARTUP_KEY = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string WINDOWS_REGISTRY_STARTUP_VALUE_NAME = "CommonScripts";
        private const string APP_EXE_NAME = "CommonScripts.Exe";
        public const string APP_HIDE_ARG = "-hide";
        public const string APP_ON_STARTUP_ARG = "-startup";

        public bool IsAppSetToRunAtStartup()
            => GetKeyFromRegistry(false)?.GetValue(GetRegistryValueName()) != null;
        public bool SetAppToRunAtStartup()
        {
            string exePath = Path.Combine(FileUtils.GetProjectPath(), APP_EXE_NAME);
            bool result = true;
            try
            {
                var key = GetKeyFromRegistry(true);
                key.SetValue(GetRegistryValueName(), $"{exePath} {APP_HIDE_ARG} {APP_ON_STARTUP_ARG}");
            }
            catch (Exception e)
            {
                Log.Error(e, "Error while saving the windows registry.");
                result = false;
            }

            return result;
        }

        public bool RemoveAppToRunAtStartup()
        {
            string exePath = Path.Combine(FileUtils.GetProjectPath(), APP_EXE_NAME);
            bool result = true;
            try
            {
                var key = GetKeyFromRegistry(true);
                key.DeleteValue(GetRegistryValueName());
            }
            catch (Exception e)
            {
                Log.Error(e, "Error while saving the windows registry.");
                result = false;
            }

            return result;
        }

        private static string GetRegistryValueName()
        {
            string valueName = WINDOWS_REGISTRY_STARTUP_VALUE_NAME;
#if DEBUG
            valueName += "_Debug";
#endif
            return valueName;
        }

        private static RegistryKey GetKeyFromRegistry(bool writable)
            => Registry.CurrentUser.OpenSubKey(WINDOWS_REGISTRY_STARTUP_KEY, writable) ?? throw new DirectoryNotFoundException("Windows registry key not found");
    }
}
