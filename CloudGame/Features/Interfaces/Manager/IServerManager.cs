using CloudGame.Features.DtoModels.Server;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGame.Features.Interfaces.Manager
{
    public interface IServerManager
    {
        Task Create(EditServerDto editServer, CancellationToken cancellationToken);
       
        Task Update(EditServerDto editServer, CancellationToken cancellationToken);
     
        Task Delete(Guid isnNode, CancellationToken cancellationToken);

        Task<EditServerDto> GetServer(Guid isnNode);

        Task<ServerDto[]> GetListServers(ServerrFilter filter);

        Task<InfoServerDto> GetInfoServer(Guid isnServer);
    }
}
