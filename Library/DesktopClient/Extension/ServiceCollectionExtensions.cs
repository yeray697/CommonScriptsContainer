using Data;
using Data.Extensions;
using Data.Repository.Interfaces;
using DesktopClient.Forms.MainForm;
using DesktopClient.Service;
using DesktopClient.Service.Interfaces;
using JobManager.Service;
using Logging;
using MaterialSkin;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopClient.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClientDependencies(this IServiceCollection serviceCollection, IRunScriptService runScriptService)
        {
            return serviceCollection
                .AddSettingServices()
                .AddSingleton<IScriptManagerService>((IServiceProvider sp) =>
                {
                    IScriptsRepository scriptRepository = sp.GetRequiredService<IScriptsRepository>();
                    return new ScriptManagerService("DesktopClient", runScriptService, scriptRepository);
                })
                .AddScoped<IWindowsRegistryService, WindowsRegistryService>()
                .AddSingleton<MainForm>();
        }
        public static IServiceCollection AddGrpcServerDependencies(this IServiceCollection serviceCollection, IRunScriptService runScriptService)
        {
            serviceCollection.AddGrpc();

            return serviceCollection
                .AddSettingServices()
                .AddSingleton<IScriptManagerService>((IServiceProvider sp) =>
            {
                IScriptsRepository scriptRepository = sp.GetRequiredService<IScriptsRepository>();
                return new ScriptManagerService("GrpcServer", runScriptService, scriptRepository);
            });
        }
        public static ServiceProvider InitClientServices(this IServiceCollection serviceCollection)
        {
            ServiceProvider serviceProvider = serviceCollection!.BuildServiceProvider();

            ISettingsRepository settingsRepository = serviceProvider.GetRequiredService<ISettingsRepository>();
            Task.Run(async () => await SettingsManager.InitInstanceAsync(settingsRepository))
                    .Wait();
            LogManager.InstanceLogger(SettingsManager.Settings);
            MaterialSkinManager.Instance.ChangeTheme(SettingsManager.Settings.App.DarkMode, true);
            
            return serviceProvider;
        }

    }
}
