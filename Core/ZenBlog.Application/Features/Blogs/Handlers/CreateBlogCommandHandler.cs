using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class CreateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(request);
            await repository.CreateAsync(blog);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(blog);
        }

     
    }
}
