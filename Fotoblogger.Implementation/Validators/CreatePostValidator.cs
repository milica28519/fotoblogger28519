using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostValidator(FotobloggerContext context)
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

            RuleFor(p => p.Photo)
                .NotEmpty();

            When(p => p.Photo != null , () =>
                RuleFor(p => p.Photo.ContentType)
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
