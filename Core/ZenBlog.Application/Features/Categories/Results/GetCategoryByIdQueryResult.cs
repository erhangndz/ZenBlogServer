using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Results
{
    public class GetCategoryByIdQueryResult : BaseDto
    {
        public string CategoryName { get; set; }
        //public IList<GetBlogQueryResult> Blogs { get; set; }
    }
}
