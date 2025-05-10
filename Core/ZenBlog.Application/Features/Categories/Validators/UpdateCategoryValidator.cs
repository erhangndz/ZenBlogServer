using FluentValidation;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Categories.Validators
{
    public class UpdateCategoryValidator: AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name is required")
                .MinimumLength(3).WithMessage("Category Name must be at least 3 characters");

            RuleFor(x => x.Id).NotEmpty().WithMessage("Category Id is required");
        }
    }
}
