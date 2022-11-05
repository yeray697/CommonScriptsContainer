using Data.Repository;
using Data.Repository.Interfaces;
using Data.Service;
using Data.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class SettingsManagerExtensions
    {
        public static IServiceCollection AddSettingServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IScriptsService, ScriptsService>()
                .AddScoped<ISettingsRepository, SettingsRepository>()
                .AddScoped<IScriptsRepository, ScriptsRepository>();
        }
    }
}
