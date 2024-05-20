using CloudGame.Logic.DtoModels;
using CloudGame.Logic.DtoModels.Filtres;
using CloudGame.Storage.Database;
using CloudGame.Storage.Models;

namespace CloudGame.Logic.Interfaces.Service
{
	public interface IOwnerService
	{
		IQueryable<Owner> GetOwnerQueryble(DataContext dataContext, OwnerFilter filter, bool asNoTracking);

		Owner GetInfoOwner(DataContext dataContext, Guid isnOwner);

        DropDownItemDto[] GetListOwnersDropDown(DataContext dataContext);

    }
}
