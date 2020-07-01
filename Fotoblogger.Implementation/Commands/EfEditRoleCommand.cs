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
    public class EfEditRoleCommand : IEditRoleCommand
    {
        private readonly FotobloggerContext _context;
        private readonly EditRoleValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfEditRoleCommand(FotobloggerContext context, EditRoleValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 7;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(EditRoleDto request)
        {
            var role = _context.Roles.Include(r => r.RoleUseCases).Where(r => r.Id == request.Id).FirstOrDefault();

            if (role == null)
                throw new EntityNotFoundException(request.Id, typeof(Role));
            
            if (role.CreatedBy != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"You can only edit roles created by you.");

            if(_actor.RoleType != RoleType.Administrator)
            {
                if (role.RoleType == RoleType.Administrator || role.RoleType == RoleType.Moderator)
                    throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"Only administrator can edit role with type {role.RoleType}.");

                if (request.RoleType == RoleType.Administrator || request.RoleType == RoleType.Moderator)
                    throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"Only administrator can change role type to {request.RoleType}.");
            }

            _validator.ValidateAndThrow(request);
            
            _mapper.Map<EditRoleDto, Role>(request, role);
            
            _context.SaveChanges(_actor.Id);
        }
    }
}
