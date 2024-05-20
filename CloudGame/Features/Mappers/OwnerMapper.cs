using AutoMapper;
using CloudGame.Features.DtoModels.Owner;
using CloudGame.Storage.Models;

namespace CloudGame.Features.Mappers
{
    public class OwnerMapper : Profile
    {
        public OwnerMapper()
        {
            CreateMap<OwnerDto, Owner>();
            CreateMap<Owner, OwnerDto>();

            CreateMap<EditOwner, Owner>();
            CreateMap<Owner, EditOwner>();
        }
    }
}
