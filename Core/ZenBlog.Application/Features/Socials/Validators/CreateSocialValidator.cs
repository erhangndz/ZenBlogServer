﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Socials.Validators
{
    public class CreateSocialValidator: AbstractValidator<CreateSocialCommand>
    {
        public CreateSocialValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Url is required.")
                .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _)).WithMessage("Url must be a valid URL.");
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon is required.")
                .MaximumLength(50).WithMessage("Icon must not exceed 50 characters.");
        }
    }
}
