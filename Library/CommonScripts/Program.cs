using CommonScripts.Logging;
using CommonScripts.Model.Repository;
using CommonScripts.Model.Repository.Interfaces;
using CommonScripts.Model.Service;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.Presenter;
using CommonScripts.View;
using Serilog;
using System;
using System.Windows.Forms;

namespace CommonScripts
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
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

        private static void ParseArgs(string[] args, out bool startAppHidden)
        {
            startAppHidden = false;
            if (args != null && args.Length == 1)
            {
                if (args[0] == "-hide")
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
    }
}
