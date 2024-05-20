using CloudGame.Storage.Database;
using CloudGame.Storage.Models;

namespace CloudGame.Logic.Interfaces.Repositories
{
	public interface IServerRepository
	{
        Server Create(DataContext dataContext, Server server);

        Server Update(DataContext dataContext, Server server);

        void Delete(DataContext dataContext, Guid IsnNode);

        Server GetById(DataContext dataContext, Guid IsnNode);
    }
}
