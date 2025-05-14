using AutoMapper;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Mappings
{
    public class CommentMappingProfile: Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, GetCommentsQueryResult>().ReverseMap();
        }
    }
}
