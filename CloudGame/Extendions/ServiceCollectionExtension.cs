using CloudGame.Features.Interfaces.Manager;
using CloudGame.Features.Manager;
using CloudGame.Features.Mappers;

namespace CloudGame.Extendions
{
    public static class ServiceCollectionExtension
    {
        public static void AddFeaturesServices(this IServiceCollection services)
        {
            services.AddTransient<IOwnerManager, OwnerManager>();
            services.AddTransient<IServerManager, ServerManeger>();
            services.AddTransient<IUserManager, UserMeneger>();
        }

        public static void AddAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(OwnerMapper),
                typeof(ServerMapper),
                typeof(UserMapper));
        }
    }
}