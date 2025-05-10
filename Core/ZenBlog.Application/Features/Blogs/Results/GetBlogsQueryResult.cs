using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Results;

public class GetBlogsQueryResult: BaseDto
{
    public string Title { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public GetCategoryQueryResult Category { get; set; }
    public string UserId { get; set; }
    //public AppUser User { get; set; }
    //public  IList<Comment> Comments { get; set; }
}