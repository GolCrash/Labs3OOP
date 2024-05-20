using AutoMapper;
using CloudGame.Features.DtoModels.Owner;
using CloudGame.Features.DtoModels.Server;
using CloudGame.Features.DtoModels.User;
using CloudGame.Features.Interfaces.Manager;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Logic.Interfaces.Repositories;
using CloudGame.Logic.Interfaces.Service;
using CloudGame.Logic.Service;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudGame.Features.Manager
{
    public class UserMeneger : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _userService;
        private readonly DataContext _dataContext;

        public UserMeneger(IMapper mapper, IUserRepository userRepository, IUserServices userService, DataContext dataContext)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userService = userService;
            _dataContext = dataContext;
        }

        public async Task Create(EditUserDto editUser, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<User>(editUser);

            _userRepository.Create(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(EditUserDto editUser, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<User>(editUser);

            _userRepository.Update(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid isnNode, CancellationToken cancellationToken)
        {

            _userRepository.Delete(_dataContext, isnNode);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<EditUserDto> GetUser(Guid isnNode)
        {
            var model = _userRepository.GetById(_dataContext, isnNode);

            return _mapper.Map<EditUserDto>(model);
        }

        public async Task SetBindWithServers(SetBlindWithServerDto model, CancellationToken cancellationToken)
        {
            _userService.SetBindWithServers(_dataContext, model.IsnUser, model.IsnServer);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteBindWithServers(SetBlindWithServerDto model, CancellationToken cancellationToken)
        {
            _userService.DeleteBindWithServers(_dataContext, model.IsnUser, model.IsnServer);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<InfoUserDto> GetInfoUser(Guid isnUser)
        {
            var model = _userService.GetInfoUser(_dataContext, isnUser);

            return new InfoUserDto
            {
                IsnNode = model.IsnNode,
                NameUser = model.NameUser,
                Tariff = model.Tariff,
                Servers = model.UserServer
                .Select(UserServers => new ServerDto
                {
                    IsnNode = UserServers.Server.IsnNode,
                    IsnOwner = UserServers.Server.IsnOwner,
                    NameServer = UserServers.Server.NameServer,
                    Games = UserServers.Server.Games,
                    Сharacteristic = UserServers.Server.Сharacteristic
                })
                .ToArray()
            };
        }

        public async Task<UserDto[]> GetListUser(UserFilter filter)
        {
            var users = _userService
                .GetUserQueryble(_dataContext, filter, false)
                .Select(x => new UserDto
                {
                    IsnNode = x.IsnNode,
                    NameUser = x.NameUser,
                    Tariff = x.Tariff,
                })
                .ToArray();
            return users;
        }

        public async Task<SelectListItem[]> GetListUsersDropDown()
        {
            var users = _userService.GetListUsersDropDown(_dataContext)
                .Select(center => new SelectListItem
                {
                    Text = center.Label,
                    Value = center.Value,
                })
                .ToArray();

            return users;
        }

        public async Task<SelectListItem[]> GetServers(Guid isnUser)
        {
            var servers = _userService
                .GetFreeServers(_dataContext, isnUser)
                .Select(server => new SelectListItem
                {
                    Value = server.IsnNode.ToString(),
                    Text = $"{server.NameServer} {server.Games} {server.Сharacteristic}"
                })
                .OrderBy(x => x.Text)
                .ToArray();

            return servers;
        }
    }
}
