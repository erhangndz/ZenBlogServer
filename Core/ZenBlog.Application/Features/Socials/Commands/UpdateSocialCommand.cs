using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands;

public record UpdateSocialCommand(Guid Id, string Title, string Url, string Icon) : IRequest<BaseResult<object>>;