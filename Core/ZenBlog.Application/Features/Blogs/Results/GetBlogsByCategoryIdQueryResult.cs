using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Results;

namespace ZenBlog.Application.Features.Blogs.Results
{
    public class GetBlogsByCategoryIdQueryResult
    {
        public Guid Id { get; set; }
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
}
