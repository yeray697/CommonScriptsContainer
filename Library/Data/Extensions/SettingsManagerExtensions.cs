using Data.Repository;
using Data.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class SettingsManagerExtensions
    {
        public static IServiceCollection AddSettingServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IFileRepository, FileRepository>();
        }
    }
}
