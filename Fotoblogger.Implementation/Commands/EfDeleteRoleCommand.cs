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
    public class EfDeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;

        public EfDeleteRoleCommand(FotobloggerContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 9;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(int id)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
                throw new EntityNotFoundException(id, typeof(Role));

            if (role.CreatedBy != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "You can only delete roles created by you.");

            if (role.RoleType == RoleType.Administrator || role.RoleType == RoleType.Moderator)
            {
                // only admin use can delete roles with type admin/moderator
                if (_actor.RoleType != RoleType.Administrator)
                    throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "Only administrator can delete role with type administrator/moderator.");
                // there has to be at least 1 admin role with at least 1 non-deleted user who is assigned to them
                else if (role.RoleType == RoleType.Administrator && !_context.Roles.Include(r => r.Users).Any(r => r.RoleType == role.RoleType && r.Id != role.Id && r.Users.Count > 0 && r.Users.Any(u => !u.IsDeleted)))
                    throw new DependencyException(UseCase.getUseCase(this.Id), _actor, $"Can't delete the only admin role that exists.");
            }

            // can't delete own assigned role
            if (role.Id == _context.Users.Find(_actor.Id).RoleId)
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, $"Can't delete role {role.Id} - {role.Name} because it is currently assigned to you.");
            
            // can't delete role while it's assigned to non-deleted users
            if (_context.Users.Any(u => !u.IsDeleted && u.RoleId == role.Id))
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, $"Can't delete role {role.Id} - {role.Name} that is currently assigned to user(s).");

            role.IsDeleted = true;

            _context.SaveChanges(_actor.Id);
        }
    }
}
