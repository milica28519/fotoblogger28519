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
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfCreateRoleCommand : ICreateRoleCommand
    {
        private readonly FotobloggerContext _context;
        private readonly CreateRoleValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EfCreateRoleCommand(FotobloggerContext context, CreateRoleValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 6;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(CreateRoleDto request)
        {
            _validator.ValidateAndThrow(request);

            if ((request.RoleType == RoleType.Administrator || request.RoleType == RoleType.Moderator) && _actor.RoleType != RoleType.Administrator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"Only administrator can create role with type {request.RoleType}.");

            var role = _mapper.Map<Role>(request);

            _context.Roles.Add(role);

            _context.SaveChanges(_actor.Id);
        }
    }
}
