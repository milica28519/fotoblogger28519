using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleDto>
    {
        public EditRoleValidator(FotobloggerContext context)
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(50)
                .Must((dto, name) => !context.Roles.Any(r => r.Name.Trim().ToLower() == name && r.Id != dto.Id))
                .WithMessage("Role with that name already exists.");

            RuleFor(r => r.AllowedUseCases)
                .NotEmpty();

            RuleFor(r => r.RoleType)
                .NotEmpty()
                .IsInEnum();

            var useCaseIdsInDB = context.UseCases.Select(uc => uc.Id).ToList();

            When(r => r.AllowedUseCases != null && r.AllowedUseCases.Any(), () =>
               RuleFor(r => r.AllowedUseCases)
                   .Must(AllowedUseCases => AllowedUseCases.ToList().TrueForAll(id => useCaseIdsInDB.Contains(id)))
                   .WithMessage($"Some use case(s) you are tring to assign to a role don't exist in database.") 
           );
                
        }
    }
}
