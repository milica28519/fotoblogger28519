using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class ChangeUserUseCasesValidator : AbstractValidator<ChangeUserUseCasesDto>
    {
        public ChangeUserUseCasesValidator(FotobloggerContext context)
        {
            RuleFor(u => u.UserId)
                .NotEmpty();

            var useCaseIdsInDB = context.UseCases.Select(uc => uc.Id).ToList();

            When(r => r.AllowedUseCases != null && r.AllowedUseCases.Any(), () =>
               RuleFor(r => r.AllowedUseCases)
                   .Must(AllowedUseCases => AllowedUseCases.ToList().TrueForAll(id => useCaseIdsInDB.Contains(id)))
                   .WithMessage($"Some use case(s) you are tring to assign to a role don't exist in database.")
           );
        }
    }
}
