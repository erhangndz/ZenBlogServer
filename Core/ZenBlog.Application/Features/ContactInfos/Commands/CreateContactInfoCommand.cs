using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands
{
    public record CreateContactInfoCommand : IRequest<BaseResult<object>>
    {
        public string Address { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string MapUrl { get; init; }
    }
    
}
