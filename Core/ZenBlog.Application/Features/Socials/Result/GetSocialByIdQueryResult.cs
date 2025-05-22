using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Result
{
    public class GetSocialByIdQueryResult: BaseDto
    {
     
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
       
    }
}
