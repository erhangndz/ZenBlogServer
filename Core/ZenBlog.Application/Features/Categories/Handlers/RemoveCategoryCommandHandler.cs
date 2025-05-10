using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers;

public class RemoveCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id);
        if (category == null)
        {
            return BaseResult<bool>.NotFound("Category Not Found");
        }

        repository.Delete(category);
        var response = await unitOfWork.SaveChangesAsync();

        return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Category couldn't be deleted");
        
    }
}