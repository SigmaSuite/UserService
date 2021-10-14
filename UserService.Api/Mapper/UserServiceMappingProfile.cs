using AutoMapper;
using UserService.Core.Entities;
using UserService.Infrastructure.Commands.User;

namespace UserService.Api.Mapper
{
    public class UserServiceMappingProfile : Profile
    {
        public UserServiceMappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
