using CloudGame.Logic.DtoModels;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Logic.Interfaces.Service;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Logic.Service
{
    public class UserService : IUserServices
    {
        public void SetBindWithServers(DataContext dataContext, Guid isnUser, Guid isnServer)
        {
            var server = dataContext.Servers.FirstOrDefault(x => x.IsnNode == isnServer)
                ?? throw new Exception($"Сервера с идентификатором {isnServer} не существует");

            var user = dataContext.Users.FirstOrDefault(x => x.IsnNode == isnUser)
                ?? throw new Exception($"Пользователя с идентификатором {isnUser} не существует");

            var UserServer = new User_Server
            {
                IsnServer = server.IsnNode,
                IsnUser = user.IsnNode
            };

            dataContext.User_Servers.Add(UserServer);
        }

        public void DeleteBindWithServers(DataContext dataContext, Guid isnUser, Guid isnServer)
        {
            var UserServer = dataContext.User_Servers.FirstOrDefault(x => x.IsnUser == isnUser && x.IsnServer == isnServer)
                ?? throw new Exception($"Связи пользователя {isnUser} c сервером {isnServer} не существует");

            dataContext.User_Servers.Remove(UserServer);
        }

        public IQueryable<User> GetUserQueryble(DataContext dataContext, UserFilter filter, bool asNoTracking)
        {
            IQueryable<User> query = dataContext.Users;

            if (asNoTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.UserName))                       //!!! Обратить внимание !!!
                query = query.Where(x => x.NameUser == filter.UserName);

            return query;
        }

        public User GetInfoUser(DataContext dataContext, Guid isnUser)
        {
            var user = dataContext.Users
                .AsNoTracking()
                .Include(x => x.UserServer)
                    .ThenInclude(x => x.Server)
                .FirstOrDefault(x => x.IsnNode == isnUser)
                    ?? throw new Exception($"Пользователя с идентификатором {isnUser} не существует");

            return user;
        }

        public DropDownItemDto[] GetListUsersDropDown(DataContext dataContext)
        {
            var users = dataContext.Users
                .AsNoTracking()
                .Select(center => new DropDownItemDto
                {
                    Label = center.NameUser,
                    Value = center.IsnNode.ToString(),
                })
                .ToArray();

            return users;
        }

         public Server[] GetFreeServers(DataContext dataContext, Guid isnUser)
         {
             if (!dataContext.Users.Any(x => x.IsnNode == isnUser))
                 throw new Exception($"Пользователя с идентификатором {isnUser} не существует");


             var servers = dataContext.Servers
                 .AsNoTracking()
                 .Where(c => c.ServerUser.Any(ct => ct.IsnUser == isnUser) &&
                    !dataContext.User_Servers.Any(tc => tc.IsnUser == isnUser && tc.IsnServer == c.IsnNode))
                 .ToArray();

             return servers;
         }

        /* public User[] GetFreeUsers(DataContext dataContext, Guid isnServer)
         {
             if (!dataContext.Centers.Any(x => x.IsnNode == isnCenter))
                 throw new Exception($"Центра с идентификатором {isnCenter} не существует");

             var users = dataContext.Owners
                 .AsNoTracking()
                 .Where(t => !dataContext.CentersTrainers.Any(ct => ct.IsnCenter == isnCenter && ct.IsnTrainer == t.IsnNode))
                 .ToArray();

             return users;
         }*/
    }
}