using AutoMapper;
using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfChangeUserRoleCommand : IChangeUserRoleCommand
    {
        private readonly FotobloggerContext _context;
        private readonly ChangeUserRoleValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfChangeUserRoleCommand(FotobloggerContext context, ChangeUserRoleValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 29;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(ChangeUserRoleDto request)
        {
            if (_actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "Only administrator or moderator can change role for users.");

            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => !u.IsDeleted && u.Id == request.UserId);

            if (user == null)
                throw new EntityNotFoundException(request.UserId, typeof(User));

            // can only perform action on role that lower than own
            if (_actor.RoleType != RoleType.Administrator && user.Role.RoleType <= _actor.RoleType)
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, "You can only perform this action on users with role types with lower priviledges than yours.");

            // can only assign roles with priviledges lower than own
            if (_actor.RoleType != RoleType.Administrator && _context.Roles.Find(request.RoleId).RoleType <= _actor.RoleType)
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, "You can only assign roles with role types with lower priviledges than yours.");

            // can't change role of administrator if he is only active user with that role
            if (user.Role.RoleType == RoleType.Administrator && !_context.Users.Include(u => u.Role).Any(u => !u.IsDeleted && u.IsActive && u.Id != user.Id && u.Role.RoleType == RoleType.Administrator))
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, $"Can't change role of only active user with role type Administraotr.");

            _validator.ValidateAndThrow(request);
            
            _mapper.Map<ChangeUserRoleDto, User>(request, user);
            
            _context.SaveChanges(_actor.Id);
        }
    }
}
