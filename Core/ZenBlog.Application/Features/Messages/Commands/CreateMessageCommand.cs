using System.Text.Json.Serialization;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public record CreateMessageCommand: IRequest<BaseResult<object>>
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Subject { get; init; }
        public string MessageBody { get; init; }
        [JsonIgnore]
        public bool IsRead { get; init; } = false;
    }
}
