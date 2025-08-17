using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    internal class GetLatest5BlogsQueryHandler(IRepository<Blog> repository,IMapper mapper) : IRequestHandler<GetLatest5BlogsQuery, BaseResult<List<GetLatest5BlogsQueryResult>>>
    {
        public async Task<BaseResult<List<GetLatest5BlogsQueryResult>>> Handle(GetLatest5BlogsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var blogs = repository.GetQuery().OrderByDescending(x => x.Id).Take(5).ToList();

                var mappedBlogs = mapper.Map<List<GetLatest5BlogsQueryResult>>(blogs);


                return BaseResult<List<GetLatest5BlogsQueryResult>>.Success(mappedBlogs);
            });
        }
    }
}
