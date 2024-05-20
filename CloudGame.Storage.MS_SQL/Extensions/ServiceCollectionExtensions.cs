using CloudGame.Storage.MS_SQL.InitDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace CloudGame.Storage.MS_SQL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStorageServices(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseInit>();
        }
    }
}
