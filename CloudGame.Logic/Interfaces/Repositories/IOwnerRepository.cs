using CloudGame.Storage.Database;
using CloudGame.Storage.Models;

namespace CloudGame.Logic.Interfaces.Repositories
{
	public interface IOwnerRepository
	{
		Owner Create(DataContext dataContext, Owner owner);

		Owner Update(DataContext dataContext, Owner owner);

		void Delete(DataContext dataContext, Guid IsnNode);

		Owner GetById(DataContext dataContext, Guid IsnNode);
	}
}
