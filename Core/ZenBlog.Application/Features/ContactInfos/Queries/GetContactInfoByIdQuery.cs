using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.ContactInfos.Result;

namespace ZenBlog.Application.Features.ContactInfos.Queries
{
    public record GetContactInfoByIdQuery(Guid Id): IRequest<BaseResult<GetContactInfoByIdQueryResult>>
    {
    }
}
