using CloudGame.Logic.DtoModels;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;

namespace CloudGame.Logic.Interfaces.Service
{
	public interface IUserServices
	{
        IQueryable<User> GetUserQueryble(DataContext dataContext, UserFilter filter, bool asNoTracking);

        User GetInfoUser(DataContext dataContext, Guid isnUser);

        void SetBindWithServers(DataContext dataContext, Guid isnUser, Guid isnServer);

        void DeleteBindWithServers(DataContext dataContext, Guid isnUser, Guid isnServer);

        DropDownItemDto[] GetListUsersDropDown(DataContext dataContext);

        Server[] GetFreeServers(DataContext dataContext, Guid isnUser);

        /*User[] GetFreeUsers(DataContext dataContext, Guid isnServer);*/
    }
}
