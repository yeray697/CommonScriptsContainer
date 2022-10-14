using CommonScripts.Logging;
using CommonScripts.Model.Repository;
using CommonScripts.Model.Repository.Interfaces;
using CommonScripts.Model.Service;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.Presenter;
using CommonScripts.Utils;
using CommonScripts.View;
using Serilog;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CommonScripts
{
    static class Program
    {
        static Mutex mutex = null;
        static readonly string applicationMutex = @"Global\fcb9566c-9987-4095-805d-691fb98559e0";

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
                RunForm(args);
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
        private static Form Injection()
        {
            LogManager.InstanceLogger();
            //Poor Man's DI
            return InjectMainForm();
        }
        private static Form InjectMainForm()
        {
            Log.Information("Starting application...");
            ISettingsRepository settingsRepository = new SettingsRepository();
            ISettingsService settingsService = new SettingsService(settingsRepository);
            IRunScriptService runScriptService = new RunScriptService();
            IWindowsRegistryService windowsRegistryService = new WindowsRegistryService();
            MainForm view = new MainForm();
            
            LogManager.GetConsoleSink().LogEmitted += view.LogEmitted;

            var presenter = new MainPresenter(view, settingsService, runScriptService, windowsRegistryService);

            return view;
        }
        private static void RunForm(string[] args)
        {
            ParseArgs(args, out bool startAppHidden);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mainForm = Injection();
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
            NativeMethods.SendMessage(
                (IntPtr)NativeMethods.HWND_BROADCAST,
                NativeMethods.WM_SHOWME,
                IntPtr.Zero,
                IntPtr.Zero);
        }
        private static void ThreadOnExit(object s, EventArgs e)
        {
            mutex.Dispose();
            Application.ThreadExit -= ThreadOnExit;
            Application.Exit();
        }
    }
}
