using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Results;

namespace ZenBlog.Application.Features.Blogs.Queries
{
    public record GetBlogByIdQuery(Guid Id): IRequest<BaseResult<GetBlogByIdQueryResult>>
    {
    }
}
