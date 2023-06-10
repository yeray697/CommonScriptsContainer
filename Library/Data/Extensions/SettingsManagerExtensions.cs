using Data.Repository;
using Data.Repository.Interfaces;
using Data.Services;
using Data.Services.Interfaces;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class SettingsManagerExtensions
    {
        public static IServiceCollection AddSettingServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<ISettingsRepository, SettingsRepository>()
                .AddScoped<IScriptsRepository, ScriptsRepository>()
                .AddSingleton<ILiteDatabase>((serviceProvider) => new LiteDatabase(DatabaseService.GetDatabasePath()))
                .AddSingleton<IDatabaseService, DatabaseService>();
        }
    }
}
