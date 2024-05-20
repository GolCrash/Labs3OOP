using CloudGame.Storage.Database;
using Microsoft.Extensions.DependencyInjection;

namespace CloudGame.Storage.MS_SQL.InitDatabase
{
    public sealed class DatabaseInit
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInit(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool ApplyMigrations()
        {
            // todo: реализация метода применения созданных миграций (накат новых миграций)
            throw new NotImplementedException();
        }

        public bool InternalSeed()
        {
            lock (typeof(DatabaseInit))
            {
                try
                {
                    using var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
                    using var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                    Seed(scope, dataContext);

                    return true;
                }
                catch (Exception ex)
                {

                }

                return false;

            }
        }

        public bool Seed(IServiceScope scope, DataContext dataContext)
        {
            throw new NotImplementedException();
        }
    }
}