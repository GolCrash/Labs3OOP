using CloudGame.Logic.Interfaces.Repositories;
using CloudGame.Logic.Interfaces.Service;
using CloudGame.Logic.Repositories;
using CloudGame.Logic.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CloudGame.Logic.Extensions
{
	public static class ServiceCollectionExcentions
	{
		public static void AddLogicServices(this IServiceCollection services)
		{
			services.AddSingleton<IOwnerService, OwnerService>();
			services.AddSingleton<IUserServices, UserService>();
			services.AddSingleton<IServerService, ServerService>();
			services.AddSingleton<IOwnerRepository, OwnerRepository>();
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<IServerRepository, ServerRepository>();
		}
	}
}
