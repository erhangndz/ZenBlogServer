using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Result;

namespace ZenBlog.Application.Features.Socials.Queries
{
    public record GetSocialByIdQuery(Guid Id) : IRequest<BaseResult<GetSocialByIdQueryResult>>
    {
    }
}
