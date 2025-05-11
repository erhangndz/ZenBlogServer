using FluentValidation;
using ZenBlog.Application.Features.Users.Commands;

namespace ZenBlog.Application.Features.Users.Validators
{
    public class CreateUserValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                                .EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }

    }
}
