using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Result
{
    public class GetCategoryQueryResult: BaseDto
    {
        public string CategoryName { get; set; }
        //public IList<GetBlogQueryResult> Blogs { get; set; }
    }
}
