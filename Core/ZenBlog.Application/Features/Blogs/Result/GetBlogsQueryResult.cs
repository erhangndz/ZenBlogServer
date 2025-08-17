using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Result;

public class GetBlogsQueryResult: BaseDto
{
    public string Title { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public GetCategoryQueryResult Category { get; set; }
    public string UserId { get; set; }
    public GetUsersQueryResult User { get; set; }
    public  IList<GetCommentsQueryResult> Comments { get; set; }
}