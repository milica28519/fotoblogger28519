using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(FotobloggerContext context)
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

            RuleFor(u => u.Username)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(30);

            RuleFor(u => u.Username)
                .Must(username => !context.Users.Any(u => !u.IsDeleted && u.Username == username))
                .WithMessage("Username is already taken.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(email => !context.Users.Any(u => !u.IsDeleted && u.Email == email))
                .WithMessage("A user with this e-mail already exists. E-mail must be unique per user.");

            When(u => u.ProfilePhoto != null, () =>
               RuleFor(u => u.ProfilePhoto.ContentType)
               .Must(x => x.Equals("image/jpeg")
                   || x.Equals("image/jpg")
                   || x.Equals("image/png")
                   || x.Equals("image/gif")
                   || x.Equals("image/tiff"))
               .WithMessage("File format is not allowed. Allowed formats are: jpg, jpeg, png, gif, tiff.")
           );
        }
    }
}
