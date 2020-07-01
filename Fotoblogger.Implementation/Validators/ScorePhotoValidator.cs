using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class ScorePhotoValidator : AbstractValidator<ScorePhotoDto>
    {
        public ScorePhotoValidator(FotobloggerContext context)
        {
            RuleFor(p => p.Score)
                .NotEmpty()
                .Must(score => score >= 1 && score <= 5)
                .WithMessage("Score must be a number between 1-5.");

            RuleFor(p => p.PhotoId)
                .NotEmpty();
        }
    }
}
