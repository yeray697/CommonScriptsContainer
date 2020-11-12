using CommonScripts.Model.Service.Interfaces;
using Microsoft.Win32;
using Serilog;
using System;

namespace CommonScripts.Model.Service
{
    public class WindowsRegistryService : IWindowsRegistryService
    {
        private const string WINDOWS_REGISTRY_STARTUP_PATH = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
        private const string WINDOWS_REGISTRY_STARTUP_KEY = "CommonScripts";

        public bool IsAppSetToRunAtStartup()
        {
            var key = Registry.GetValue(WINDOWS_REGISTRY_STARTUP_PATH,
             WINDOWS_REGISTRY_STARTUP_KEY
             , null);
            return key != null;
        }
        public bool SetAppToRunAtStartup()
        {
            string exePath = System.Windows.Forms.Application.StartupPath + "CommonScripts.Exe";
            string args = "-hide";
            bool result = true;
            try
            {
                Registry.SetValue(WINDOWS_REGISTRY_STARTUP_PATH,
                 WINDOWS_REGISTRY_STARTUP_KEY,
                 exePath + " " + args);
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
