using CloudGame.Logic.DtoModels;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Logic.Interfaces.Service;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Logic.Service
{
	public class OwnerService : IOwnerService
	{
		public IQueryable<Owner> GetOwnerQueryble(DataContext dataContext, OwnerFilter filter, bool asNoTracking)
		{
			IQueryable<Owner> query = dataContext.Owners;

			if (asNoTracking)
				query = query.AsNoTracking();

			if (!string.IsNullOrEmpty(filter.OwnerName))                     //!!! Обратить внимание !!!
                query = query.Where(x => x.NameOwn == filter.OwnerName);

			return query;
		}

        public Owner GetInfoOwner(DataContext dataContext, Guid isnOwner)
        {
            var owner = dataContext.Owners
                .AsNoTracking()
                .Include(x => x.Servers)
                .FirstOrDefault(x => x.IsnNode == isnOwner)
                    ?? throw new Exception($"Владельца с идентификатором {isnOwner} не существует");

            return owner;
        }

        public DropDownItemDto[] GetListOwnersDropDown(DataContext dataContext)
        {
            var owners = dataContext.Owners
                .AsNoTracking()
                .Select(center => new DropDownItemDto
                {
                    Label = center.NameOwn,
                    Value = center.IsnNode.ToString(),
                })
                .ToArray();

            return owners;
        }
    }
}
