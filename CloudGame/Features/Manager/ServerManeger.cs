using AutoMapper;
using CloudGame.Features.DtoModels.Owner;
using CloudGame.Features.DtoModels.Server;
using CloudGame.Features.DtoModels.User;
using CloudGame.Features.Interfaces.Manager;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Logic.Interfaces.Repositories;
using CloudGame.Logic.Interfaces.Service;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;

namespace CloudGame.Features.Manager
{
    public sealed class ServerManeger : IServerManager
    {
        private readonly IMapper _mapper;
        private readonly IServerRepository _serverRepository;
        private readonly IServerService _serverService;
        private readonly DataContext _dataContext;

        public ServerManeger(IMapper mapper, IServerRepository serverRepository, IServerService serverService, DataContext dataContext)
        {
            _mapper = mapper;
            _serverRepository = serverRepository;
            _serverService = serverService;
            _dataContext = dataContext;
        }

        public async Task Create(EditServerDto editServer, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Server>(editServer);

            _serverRepository.Create(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(EditServerDto editServer, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Server>(editServer);

            _serverRepository.Update(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid isnNode, CancellationToken cancellationToken)
        {

            _serverRepository.Delete(_dataContext, isnNode);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<EditServerDto> GetServer(Guid isnNode)
        {
            var model = _serverRepository.GetById(_dataContext, isnNode);

            return _mapper.Map<EditServerDto>(model);
        }

        public async Task<ServerDto[]> GetListServers(ServerrFilter filter)
        {
            var servers = _serverService
                .GetServerQueryble(_dataContext, filter, false)
                .Select(servers => new ServerDto
                {
                    IsnNode = servers.IsnNode,
                    IsnOwner = servers.IsnOwner,
                    NameServer = servers.NameServer,
                    Games = servers.Games,
                    Сharacteristic = servers.Сharacteristic,
                })
                .ToArray();

            return servers;
        }

        public async Task<InfoServerDto> GetInfoServer(Guid isnServer)
        {
            var server = _serverService.GetInfoServer(_dataContext, isnServer);

            return new InfoServerDto
            {
                IsnNode = server.IsnNode,
                IsnOwner = server.IsnOwner,
                NameServer = server.NameServer,
                Games = server.Games,
                Сharacteristic = server.Сharacteristic,
                Owners = new OwnerDto
                {
                    IsnNode = server.Owner.IsnNode,
                    NameOwn = server.Owner.NameOwn,
                    DataRegistration = server.Owner.DataRegistration
                },
                Users = server.ServerUser
                .Select(serverUser => new UserDto
                {
                    IsnNode = serverUser.User.IsnNode,
                    NameUser = serverUser.User.NameUser,
                    Tariff = serverUser.User.Tariff
                })
                .ToArray()
            };
        }
    }
        
}
