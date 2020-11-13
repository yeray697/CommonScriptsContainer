using CommonScripts.Logging;
using CommonScripts.Model.Repository;
using CommonScripts.Model.Repository.Interfaces;
using CommonScripts.Model.Service;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.Presenter;
using CommonScripts.View;
using Serilog;
using Serilog.Core;
using Serilog.Events;
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
            bool startAppHidden = false;
            ParseArgs(args, out startAppHidden);
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
            var sink = new LogSink();
            InstanceLogger(sink);
            //Poor Man's DI
            return InjectMainForm(sink);
        }

        private static Form InjectMainForm(LogSink sink)
        {
            Log.Information("Starting application...");
            ISettingsRepository settingsRepository = new SettingsRepository();
            ISettingsService settingsService = new SettingsService(settingsRepository);
            IRunScriptService runScriptService = new RunScriptService();
            IWindowsRegistryService windowsRegistryService = new WindowsRegistryService();
            MainForm view = new MainForm();
            sink.LogEmitted += view.LogEmitted;

            var presenter = new MainPresenter(view, settingsService, runScriptService, windowsRegistryService);

            return view;
        }

        private static void InstanceLogger(ILogEventSink sink)
        {
            var logPath = @"logs\CommonScripts.log";
            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Quartz", LogEventLevel.Warning);

            loggerConfiguration
                .WriteTo.Console()
                .WriteTo.File(logPath)
                .WriteTo.Sink(sink);

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }
}
