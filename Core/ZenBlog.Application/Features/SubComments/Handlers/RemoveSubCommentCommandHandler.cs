using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class RemoveSubCommentCommandHandler(IRepository<SubComment> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = await repository.GetByIdAsync(request.Id);
            if (subComment == null)
            {
                return BaseResult<object>.Fail("SubComment not found");
            }
            repository.Delete(subComment);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("SubComment Deleted");
        }
    }
}
