using Data;
using DesktopClient.Extension;
using DesktopClient.Forms;
using DesktopClient.Forms.MainForm;
using DesktopClient.Models;
using DesktopClient.Utils;
using JobManager.Service;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Windows.Forms.Design;

namespace App
{
    internal static class Program
    {
        private static IServiceCollection? ServiceCollection { get; set; }
        private static ServiceProvider? ServiceProvider { get; set; }
        private static IRunScriptService? RunScriptService { get; set; }
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
                NativeMethods.BringInstanceToForeground();
                Application.ExitThread();
            }
            else
            {
                RunScriptService = new RunScriptService();
                ClientArguments clientArguments = new(args);

                ServiceCollection = new ServiceCollection()
                    .AddClientDependencies(RunScriptService);
                ServiceProvider = ServiceCollection.InitClientServices();

                WebHost.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services
                            .AddSingleton(RunScriptService)
                            .AddGrpc();
                    })
                    .Configure(app =>
                    {
                        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                        {
                            app.UseDeveloperExceptionPage();
                        }
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGrpcService<RunScriptGrpcService>();
                            endpoints.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                        });
                    })
                    .Build()
                    .RunAsync();

                RunForm(clientArguments);
            }
        }
        private static void RunForm(ClientArguments clientArguments)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!OpenInstallFormIfNeeded())
                return;
            var mainForm = ServiceProvider!.GetService<MainForm>()!;
            Log.Information("Starting application...");
            mainForm.Setup(clientArguments);
            Application.Run(mainForm);
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
        private static void ThreadOnExit(object? s, EventArgs e)
        {
            if (IsInstallationFormOpen)
                return;
            DisposeObjects();
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