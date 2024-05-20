using CloudGame.Features.DtoModels.Owner;
using CloudGame.Logic.DtoModels.Filtres;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudGame.Features.Interfaces.Manager
{
    public interface IOwnerManager
    {
        Task Create(EditOwner editOwner, CancellationToken cancellationToken);

        Task Update(EditOwner editOwner, CancellationToken cancellationToken);

        Task Delete(Guid isnNode, CancellationToken cancellationToken);

        Task<EditOwner> GetOwner(Guid isnNode);

        Task<InfoOwnerDto> GetInfoOwner(Guid isnOwner);

        Task<OwnerDto[]> GetListOwner(OwnerFilter filter);

        Task<SelectListItem[]> GetListOwnersDropDown();
    }
}
