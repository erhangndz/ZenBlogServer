using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands;

public record RemoveSocialCommand(Guid Id) : IRequest<BaseResult<object>>;