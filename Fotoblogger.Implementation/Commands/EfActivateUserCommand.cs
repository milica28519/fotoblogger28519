using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfActivateUserCommand : IActivateUserCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;
        private readonly ActivateUserValidator _validator;

        public EfActivateUserCommand(FotobloggerContext context, IApplicationActor actor, ActivateUserValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }

        public int Id => 28;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(ActivateUserDto request)
        {
            if (_actor.Id != 0 && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "You can only reactivate your own user profile.");

            User user ;
            int actorId;

            // user ativating his own deactivated acocunt it must confirm his password
            if (_actor.Id == 0)
            {
                _validator.ValidateAndThrow(request);

                user = _context.Users.FirstOrDefault(u => !u.IsDeleted && u.Id == request.Id);

                CheckIfNull(user);

                if (user.Password != request.Password)
                    throw new WrongPasswordException(UseCase.getUseCase(this.Id), _actor);

                actorId = user.Id;
            }
            else
            {
                user = _context.Users.Include(u => u.Role).FirstOrDefault(u => !u.IsDeleted && u.Id == request.Id);

                CheckIfNull(user);

                // can't delete own user or user with role less than own role (moderator cannot delete other moderator's only amdinistrator can) 
                if (_actor.RoleType != RoleType.Administrator && user.Role.RoleType == _actor.RoleType)
                    throw new DependencyException(UseCase.getUseCase(this.Id), _actor, $"You have no priviledges to activate user with the same role as yours.");
                
                actorId = user.Id;
            }

            if (user.IsActive)
                throw new ActionNotRepeatableException(UseCase.getUseCase(this.Id), _actor);

            user.IsActive = true;
            user.DeactivatedAt = null;

            _context.SaveChanges(actorId);
        }

        private void CheckIfNull(User user)
        {
            if (user == null)
                throw new EntityNotFoundException(0, typeof(User));
        }
    }
}
