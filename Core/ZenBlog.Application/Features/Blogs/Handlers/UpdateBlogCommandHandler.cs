using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class UpdateBlogCommandHandler(IRepository<Blog> _repository, IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<Blog>(request);
            _repository.Update(blog);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog has been updated successfully");
        }
    }
}
