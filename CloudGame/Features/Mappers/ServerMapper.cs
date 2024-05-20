using AutoMapper;
using CloudGame.Features.DtoModels.Server;
using CloudGame.Storage.Models;

namespace CloudGame.Features.Mappers
{
    public class ServerMapper : Profile
    {
        public ServerMapper()
        {
            CreateMap<ServerDto, Server>();
            CreateMap<Server, ServerDto>();

            CreateMap<EditServerDto, Server>();
            CreateMap<Server, EditServerDto>();
        }
    }
}
