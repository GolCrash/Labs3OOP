using CloudGame.Features.DtoModels.User;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGame.Features.Interfaces.Manager
{
    public interface IUserManager
    {
        Task Create(EditUserDto editUser, CancellationToken cancellationToken);

        Task Update(EditUserDto editUser, CancellationToken cancellationToken);

        Task Delete(Guid isnNode, CancellationToken cancellationToken);

        Task<EditUserDto> GetUser(Guid isnNode);

        Task SetBindWithServers(SetBlindWithServerDto model, CancellationToken cancellationToken);
        
        Task DeleteBindWithServers(SetBlindWithServerDto model, CancellationToken cancellationToken);

        Task<InfoUserDto> GetInfoUser(Guid isnUser);

        Task<UserDto[]> GetListUser(UserFilter filter);

        Task<SelectListItem[]> GetServers(Guid isnUser);

        Task<SelectListItem[]> GetListUsersDropDown();
    }
}
