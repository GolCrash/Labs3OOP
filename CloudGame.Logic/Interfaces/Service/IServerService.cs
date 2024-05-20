using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Logic.DtoModels;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;

namespace CloudGame.Logic.Interfaces.Service
{
	public interface IServerService
	{
        IQueryable<Server> GetServerQueryble(DataContext dataContext, ServerrFilter filter, bool asNoTracking);

        Server GetInfoServer(DataContext dataContext, Guid isnServer);
    }
}
