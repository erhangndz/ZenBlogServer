using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class RemoveCommentCommandHandler(IRepository<Comment> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if (comment is null)
            {
                return BaseResult<object>.NotFound("Comment Not Found");
            }
            _repository.Delete(comment);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Comment Deleted");
        }
    }
}
