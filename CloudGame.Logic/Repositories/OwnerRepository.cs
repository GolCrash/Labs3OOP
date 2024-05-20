using CloudGame.Logic.Interfaces.Repositories;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Logic.Repositories
{
	public class OwnerRepository : IOwnerRepository
	{
		public Owner Create(DataContext dataContext, Owner owner)
		{
			owner.IsnNode = Guid.NewGuid();
			dataContext.Owners.Add(owner);

			return owner; 
		}

		public Owner Update(DataContext dataContext, Owner owner)
		{
			var ownerDb = dataContext.Owners.FirstOrDefault(x => x.IsnNode == owner.IsnNode)
				?? throw new Exception($"Индефикатор владельца {owner.IsnNode} не неайден");
			
			ownerDb.NameOwn = owner.NameOwn;
			ownerDb.DataRegistration = owner.DataRegistration;

			return ownerDb;
		}

		public void Delete(DataContext dataContext, Guid IsnNode)
		{
			var ownerDb = dataContext.Owners.FirstOrDefault(x => x.IsnNode == IsnNode)
				?? throw new Exception($"Индефикатор владельца {IsnNode} не неайден");

			dataContext.Owners.Remove(ownerDb);	
		}

		public Owner GetById(DataContext dataContext, Guid IsnNode) 
		{
			var ownerDb = dataContext.Owners.AsNoTracking().FirstOrDefault(x => x.IsnNode == IsnNode)
				?? throw new Exception($"Индефикатор владельца {IsnNode} не неайден");

			return ownerDb;
		}
	}
}
