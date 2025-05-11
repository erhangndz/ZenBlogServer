using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile: Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogByIdQueryResult>().ReverseMap();
        }
    }
}
