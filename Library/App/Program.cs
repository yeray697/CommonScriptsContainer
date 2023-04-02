using Data;
using DesktopClient.Extension;
using DesktopClient.Forms.MainForm;
using DesktopClient.Models;
using DesktopClient.Service;
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
                IRunScriptService runScriptService = new RunScriptService();
                ClientArguments clientArguments = new(args);

                ServiceCollection = new ServiceCollection()
                    .AddClientDependencies(runScriptService);
                ServiceProvider = ServiceCollection.InitClientServices();

                RunGrpcServer(args, runScriptService);
                RunWebClient(args);
                RunForm(clientArguments);
            }
        }
        private static void RunGrpcServer(string[] args, IRunScriptService runScriptService)
        {
            if (!SettingsManager.Settings.Core.EnableGrpcServer)
                return;
            WebHost.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddGrpcServerDependencies(runScriptService);
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
        }
        private static void RunWebClient(string[] args)
        {
            if (!SettingsManager.Settings.Core.EnableWebClient)
                return;
        }
        private static void RunForm(ClientArguments clientArguments)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = ServiceProvider!.GetService<MainForm>()!;
            Log.Information("Starting application...");
            mainForm.Setup(clientArguments);
            Application.Run(mainForm);
        }
        private static void ThreadOnExit(object? s, EventArgs e)
        {
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