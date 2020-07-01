using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfDeactivateUserCommand : IDeactivateUserCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;

        public EfDeactivateUserCommand(FotobloggerContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 27;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(int id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => !u.IsDeleted && u.Id == id);

            if (user == null)
                throw new EntityNotFoundException(id, typeof(User));

            if (!user.IsActive)
                throw new ActionNotRepeatableException(UseCase.getUseCase(this.Id), _actor);

            if (user.Id != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "You can only deactivate your own user profile.");

            // can't delete own user or user with role less than own role (moderator cannot delete other moderator's only amdinistrator can) 
            if (_actor.RoleType != RoleType.Administrator && user.Role.RoleType == _actor.RoleType)
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, $"You have no priviledges to deactivate user with the same role as you.");
            
            // can't delete user if it has role Administrato and is only one with that role who is not deleted
            if (user.Role.RoleType == RoleType.Administrator && !_context.Users.Any(u => !u.IsDeleted && u.Id != id && u.Role.RoleType == RoleType.Administrator))
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, $"Can't deactivate user {user.Id} - {user.Username} who is only administrator.");

            user.IsActive = false;
            user.DeactivatedAt = DateTime.UtcNow;

            _context.SaveChanges(_actor.Id);
        }
    }
}
