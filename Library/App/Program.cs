using App.Extension;
using App.Forms.MainForm;
using App.Service;
using App.Service.Interfaces;
using App.Utils;
using Data;
using Data.Extensions;
using JobManager.Service;
using Logging;
using MaterialSkin;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace App
{
    internal static class Program
    {
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
        private static void ParseArgs(string[] args, out bool startAppHidden)
        {
            startAppHidden = false;
            if (args != null && args.Length == 1)
            {
                if (args[0] == WindowsRegistryService.APP_HIDE_ARG)
                    startAppHidden = true;
            }
        }
        private static void InitForm(string[] args)
        {
            ParseArgs(args, out bool startAppHidden);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            RunForm(startAppHidden);
        }
        private static void RunForm(bool startAppHidden)
        {
            using ServiceProvider serviceProvider = ServiceCollection!.BuildServiceProvider();
            Data.Service.ISettingsService settingsService = serviceProvider.GetRequiredService<Data.Service.ISettingsService>();
            Task.Run(async () => await SettingsManager.InitInstanceAsync(settingsService))
                .Wait();
            LogManager.InstanceLogger(SettingsManager.Settings);
            MaterialSkinManager.Instance.ChangeTheme(SettingsManager.Settings.App.DarkMode, true);

            var mainForm = serviceProvider.GetService<MainForm>()!;
            Log.Information("Starting application...");
            if (startAppHidden)
            {
                mainForm.WindowState = FormWindowState.Minimized;
                mainForm.Hide();
                mainForm.ShowInTaskbar = false;
            }
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
            mutex?.Dispose();
            Application.ThreadExit -= ThreadOnExit;
            Application.Exit();
        }
        private static IServiceCollection? ServiceCollection { get; set; }
        private static void ConfigureServices()
        {
            ServiceCollection = new ServiceCollection();
            ServiceCollection
                .AddSettingServices()
                .AddScoped<IRunScriptService, RunScriptService>()
                .AddScoped<IWindowsRegistryService, WindowsRegistryService>()
                .AddSingleton<MainForm>();
        }
    }
}