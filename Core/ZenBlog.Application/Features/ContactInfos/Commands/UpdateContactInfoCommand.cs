using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands
{
    public record UpdateContactInfoCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string MapUrl { get; init; }
    }
  
}
