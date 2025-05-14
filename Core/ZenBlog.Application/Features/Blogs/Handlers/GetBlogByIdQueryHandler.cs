using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class GetBlogByIdQueryHandler(IRepository<Blog> repository,IMapper mapper) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            if (value is null)
            {
                return BaseResult<GetBlogByIdQueryResult>.NotFound("Blog Not Found");
            }

            var blog = mapper.Map<GetBlogByIdQueryResult>(value);

            return BaseResult<GetBlogByIdQueryResult>.Success(blog);
        }
    }
}
