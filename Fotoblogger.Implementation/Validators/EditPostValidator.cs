using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class EditPostValidator : AbstractValidator<EditPostDto>
    {
        public EditPostValidator(FotobloggerContext context)
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(p => p.Text)
                .MaximumLength(10000);

            RuleFor(u => u.PhotoCaption)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);
        }
    }
}
