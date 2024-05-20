using CloudGame.Logic.Interfaces.Repositories;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Logic.Repositories
{
	public class ServerRepository : IServerRepository
	{
        public Server Create(DataContext dataContext, Server server)
        {
            server.IsnNode = Guid.NewGuid();
            dataContext.Servers.Add(server);

            return server;
        }

        public Server Update(DataContext dataContext, Server server)
        {
            var serverDb = dataContext.Servers.FirstOrDefault(x => x.IsnNode == server.IsnNode)
                ?? throw new Exception($"Индефикатор сервера {server.IsnNode} не неайден");

            var owner = dataContext.Owners.FirstOrDefault(x => x.IsnNode == server.IsnOwner)
                ?? throw new Exception($"Индефикатор владельца {server.IsnNode} не неайден");

            serverDb.IsnOwner = server.IsnOwner;
            serverDb.NameServer = server.NameServer;
            serverDb.Games = server.Games;
            serverDb.Сharacteristic = server.Сharacteristic;
            serverDb.Owner = server.Owner;

            return serverDb;
        }

        public void Delete(DataContext dataContext, Guid IsnNode)
        {
            var serverDb = dataContext.Servers.FirstOrDefault(x => x.IsnNode == IsnNode)
                ?? throw new Exception($"Индефикатор сервера {IsnNode} не неайден");

            dataContext.Servers.Remove(serverDb);
        }

        public Server GetById(DataContext dataContext, Guid IsnNode)
        {
            var serverDb = dataContext.Servers.AsNoTracking().FirstOrDefault(x => x.IsnNode == IsnNode)
                ?? throw new Exception($"Индефикатор сервера {IsnNode} не неайден");

            return serverDb;
        }
    }
}
