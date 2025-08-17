using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Blogs.Queries;

public record GetLatest5BlogsQuery : IRequest<BaseResult<List<GetLatest5BlogsQueryResult>>>;

