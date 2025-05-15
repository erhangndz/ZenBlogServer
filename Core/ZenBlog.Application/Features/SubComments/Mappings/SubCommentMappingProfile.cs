using AutoMapper;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Mappings
{
    public class SubCommentMappingProfile: Profile
    {
        public SubCommentMappingProfile()
        {
            CreateMap<SubComment, CreateSubCommentCommand>().ReverseMap();
            CreateMap<SubComment, GetSubCommentsQueryResult>().ReverseMap();
        }
    }
}
