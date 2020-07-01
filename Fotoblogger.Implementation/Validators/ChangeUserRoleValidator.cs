using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class ChangeUserRoleValidator : AbstractValidator<ChangeUserRoleDto>
    {
        public ChangeUserRoleValidator(FotobloggerContext context)
        {
            RuleFor(r => r.UserId)
                .NotEmpty();

            RuleFor(r => r.RoleId)
                .NotEmpty()
                .Must(roleId => context.Roles.Any(r => r.Id == roleId))
                .WithMessage("Role doesn't exist.");
        }
    }
}
