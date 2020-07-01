using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class ActivateUserValidator : AbstractValidator<ActivateUserDto>
    {
        public ActivateUserValidator(FotobloggerContext context)
        {
            RuleFor(u => u.Password)
                .NotEmpty();
        }
    }
}
