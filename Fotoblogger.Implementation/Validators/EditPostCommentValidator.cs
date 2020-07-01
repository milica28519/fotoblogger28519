using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class EditPostCommentValidator : AbstractValidator<EditPostCommentDto>
    {
        public EditPostCommentValidator(FotobloggerContext context)
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(c => c.Text)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(10000);
        }
    }
}
