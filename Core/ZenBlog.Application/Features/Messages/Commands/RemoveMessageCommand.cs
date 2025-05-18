using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public record RemoveMessageCommand(Guid Id) : IRequest<BaseResult<object>>
    {
    }
}
