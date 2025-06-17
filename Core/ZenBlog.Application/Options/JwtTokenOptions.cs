using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBlog.Application.Options
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; } // api.zenblog.com
        public string Audience { get; set; } //www.zenblog.com
        public string Key { get; set; }
        public int ExpireInMinutes { get; set; }
    }
}
