using App.Extension;
using App.Forms;
using App.Forms.MainForm;
using App.Service;
using App.Service.Interfaces;
using App.Utils;
using Data;
using Data.Extensions;
using Data.Service.Interfaces;
using JobManager.Service;
using Logging;
using MaterialSkin;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Windows.Forms.Design;

namespace App
{
    internal static class Program
    {
        private static IServiceCollection? ServiceCollection { get; set; }
        private static ServiceProvider? ServiceProvider { get; set; }
        private static bool IsInstallationFormOpen = false;
        static Mutex? mutex = null;
#if DEBUG
        static readonly string applicationMutex = @"Global\fcb9566c-9987-4095-805d-691fb98559e0-Debug";
#else
        static readonly string applicationMutex = @"Global\fcb9566c-9987-4095-805d-691fb98559e0";
#endif

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.ThreadExit += ThreadOnExit;
            mutex = new Mutex(true, applicationMutex);
            bool singleInstance = mutex.WaitOne(0, false);
            if (!singleInstance)
            {
                BringInstanceToForeground();
                Application.ExitThread();
            } 
            else
               InitForm(args);
        }
        private static void ParseArgs(string[] args, out bool startAppHidden, out bool onStartup)
        {
            startAppHidden = false;
            onStartup = false;
            if (args != null)
            {
                foreach (var arg in args)
                {
                    if (arg == WindowsRegistryService.APP_HIDE_ARG)
                        startAppHidden = true;
                    else if (arg == WindowsRegistryService.APP_ON_STARTUP_ARG)
                        onStartup = true;

                }
            }
        }
        private static void InitForm(string[] args)
        {
            ParseArgs(args, out bool startAppHidden, out bool onStartup);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            InitServices();
            RunForm(startAppHidden, onStartup);
        }
        private static void InitServices()
        {
            ServiceProvider = ServiceCollection!.BuildServiceProvider();
            ISettingsService settingsService = ServiceProvider.GetRequiredService<ISettingsService>();
            Task.Run(async () => await SettingsManager.InitInstanceAsync(settingsService))
                .Wait();
            LogManager.InstanceLogger(SettingsManager.Settings);
            MaterialSkinManager.Instance.ChangeTheme(SettingsManager.Settings.App.DarkMode, true);
        }
        private static void RunForm(bool startAppHidden, bool onStartup)
        {
            if (!OpenInstallFormIfNeeded())
                return;
            var mainForm = ServiceProvider!.GetService<MainForm>()!;
            Log.Information("Starting application...");
            if (startAppHidden)
            {
                mainForm.WindowState = FormWindowState.Minimized;
                mainForm.Hide();
                mainForm.ShowInTaskbar = false;
            }
            mainForm.RunOnStartup = onStartup;
            Application.Run(mainForm);
        }
        private static void BringInstanceToForeground()
        {
            _ = NativeMethods.SendMessage(
                (IntPtr)NativeMethods.HWND_BROADCAST,
                NativeMethods.WM_SHOWME,
                IntPtr.Zero,
                IntPtr.Zero);
        }
        private static void ThreadOnExit(object? s, EventArgs e)
        {
            if (IsInstallationFormOpen)
                return;
            DisposeObjects();
        }
        private static void ConfigureServices()
        {
            ServiceCollection = new ServiceCollection();
            ServiceCollection
                .AddSettingServices()
                .AddScoped<IRunScriptService, RunScriptService>()
                .AddScoped<IWindowsRegistryService, WindowsRegistryService>()
                .AddSingleton<MainForm>();
        }
        private static bool OpenInstallFormIfNeeded()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(SettingsManager.Settings.Core.InstallationPath))
            {
                var installationPathForm = new SetInstallationPathForm
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                IsInstallationFormOpen = true;
                Application.Run(installationPathForm);
                if (installationPathForm.DialogResult == DialogResult.OK)
                {
                    Task.Run(async () => await SettingsManager.UpdateSettingsAsync((settings) => settings.Core.InstallationPath = installationPathForm.InstallationPath!))
                        .Wait();
                    Application.Exit();
                }
                else
                {
                    DisposeObjects();
                    result = false;
                }
                IsInstallationFormOpen = false;
            }
            return result;
        }
        private static void DisposeObjects()
        {
            mutex?.Dispose();
            ServiceProvider?.Dispose();
            Application.ThreadExit -= ThreadOnExit;
            Application.Exit();
        }
    }
}