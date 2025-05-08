using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Results
{
    public class GetCategoryByIdQueryResult : BaseDto
    {
        public string CategoryName { get; set; }
        //public IList<GetBlogQueryResult> Blogs { get; set; }
    }
}
