using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Commands;

public record RemoveBlogCommand(Guid Id) : IRequest<BaseResult<object>>;