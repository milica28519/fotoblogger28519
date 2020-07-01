using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class SetUserProfilePhotoValidator : AbstractValidator<SetUserProfilePhotoDto>
    {
        public SetUserProfilePhotoValidator(FotobloggerContext context)
        {
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
