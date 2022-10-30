using JobManager.Service;
using Microsoft.Extensions.DependencyInjection;

namespace JobManager.Extensions
{
    public static class JobManagerExtensions
    {
        public static IServiceCollection AddJobManagerServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IRunScriptService, RunScriptService>();
        }
    }
}
