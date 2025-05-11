using AutoMapper;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Mappings
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AppUser, CreateUserCommand>().ReverseMap();
        }
    }
}
