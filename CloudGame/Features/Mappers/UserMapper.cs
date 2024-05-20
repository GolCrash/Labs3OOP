using AutoMapper;
using CloudGame.Features.DtoModels.User;
using CloudGame.Storage.Models;

namespace CloudGame.Features.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<EditUserDto, User>();
            CreateMap<User, EditUserDto>();
        }
    }
}
