using Data;
using Data.Extensions;
using Data.Service.Interfaces;
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
                .AddSingleton(runScriptService)
                .AddScoped<IWindowsRegistryService, WindowsRegistryService>()
                .AddSingleton<MainForm>();
        }

        public static ServiceProvider InitClientServices(this IServiceCollection serviceCollection)
        {
            ServiceProvider serviceProvider = serviceCollection!.BuildServiceProvider();
            
            ISettingsService settingsService = serviceProvider.GetRequiredService<ISettingsService>();
            Task.Run(async () => await SettingsManager.InitInstanceAsync(settingsService))
                    .Wait();
            LogManager.InstanceLogger(SettingsManager.Settings);
            MaterialSkinManager.Instance.ChangeTheme(SettingsManager.Settings.App.DarkMode, true);
            
            return serviceProvider;
        }
    }
}
