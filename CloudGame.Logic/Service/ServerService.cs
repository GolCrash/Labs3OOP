using CloudGame.Logic.DtoModels;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Logic.Interfaces.Service;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Logic.Service
{
    public class ServerService : IServerService
	{
        public IQueryable<Server> GetServerQueryble(DataContext dataContext, ServerrFilter filter, bool asNoTracking)
        {
            IQueryable<Server> query = dataContext.Servers;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.ServerName))                       //!!! Обратить внимание !!!
                query = query.Where(x => x.NameServer == filter.ServerName);

            return query;
        }

        public Server GetInfoServer(DataContext dataContext, Guid isnServer)
        {
            var server = dataContext.Servers
                .AsNoTracking()
                .Include(x => x.Owner)
                .Include(x => x.ServerUser)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.IsnNode == isnServer)
                    ?? throw new Exception($"Сервера с идентификатором {isnServer} не существует");

            return server;
        }
    }
}
