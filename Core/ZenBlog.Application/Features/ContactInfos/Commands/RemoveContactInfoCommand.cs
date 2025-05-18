using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands
{
    public record RemoveContactInfoCommand(Guid Id) : IRequest<BaseResult<object>>
    {
    }
}
