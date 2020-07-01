using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        public EditUserValidator(FotobloggerContext context)
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(u => u.LastName)
                .NotEmpty()
                .MaximumLength(50);
            
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(50);

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .Must((dto,email) => !context.Users.Any(u => !u.IsDeleted && u.Email == email && u.Id != dto.Id))
                .WithMessage("A user with this e-mail already exists. E-mail must be unique per user.");
        }
    }
}
