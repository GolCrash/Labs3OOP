using CloudGame.Logic.Interfaces.Repositories;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Logic.Repositories
{
	public class UserRepository : IUserRepository
	{
        public User Create(DataContext dataContext, User user)
        {
            user.IsnNode = Guid.NewGuid();
            dataContext.Users.Add(user);

            return user;
        }

        public User Update(DataContext dataContext, User user)
        {
            var userDb = dataContext.Users.FirstOrDefault(x => x.IsnNode == user.IsnNode)
                ?? throw new Exception($"Индефикатор пользователя  {user.IsnNode} не неайден");

            userDb.NameUser = user.NameUser;
            userDb.Tariff = user.Tariff;

            return userDb;
        }

        public void Delete(DataContext dataContext, Guid IsnNode)
        {
            var serverDb = dataContext.Users.FirstOrDefault(x => x.IsnNode == IsnNode)
                ?? throw new Exception($"Индефикатор пользователя  {IsnNode} не неайден");

            dataContext.Users.Remove(serverDb);
        }

        public User GetById(DataContext dataContext, Guid IsnNode)
        {
            var userDb = dataContext.Users.AsNoTracking().FirstOrDefault(x => x.IsnNode == IsnNode)
                ?? throw new Exception($"Индефикатор пользователя {IsnNode} не неайден");

            return userDb;
        }
    }
}
