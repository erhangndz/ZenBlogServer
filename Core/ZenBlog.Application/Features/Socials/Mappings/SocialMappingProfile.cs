using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Mappings
{
    public class SocialMappingProfile: Profile
    {
        public SocialMappingProfile()
        {
            CreateMap<Social, CreateSocialCommand>().ReverseMap();
            CreateMap<Social, GetSocialsQueryResult>().ReverseMap();
            CreateMap<Social, GetSocialByIdQueryResult>().ReverseMap();
            CreateMap<Social, UpdateSocialCommand>().ReverseMap();
        }
    }
}
