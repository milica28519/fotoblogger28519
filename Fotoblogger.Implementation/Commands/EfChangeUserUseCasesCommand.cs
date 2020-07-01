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
    public class EfChangeUserUseCasesCommand : IChangeUserUseCasesCommand
    {
        private readonly FotobloggerContext _context;
        private readonly ChangeUserUseCasesValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfChangeUserUseCasesCommand(FotobloggerContext context, ChangeUserUseCasesValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 30;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(ChangeUserUseCasesDto request)
        {
            if (_actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "Only administrator or moderator can change permissions for users.");

            var user = _context.Users.Include(u => u.Role).Include(u => u.UseCases).FirstOrDefault(r => r.Id == request.UserId);

            if (user == null)
                throw new EntityNotFoundException(request.UserId, typeof(User));

            // can only perform action on role that lower than own
            if (_actor.RoleType != RoleType.Administrator && user.Role.RoleType <= _actor.RoleType)
                throw new DependencyException(UseCase.getUseCase(this.Id), _actor, "You can only perform this action on users with role types with lower priviledges than yours.");

            _validator.ValidateAndThrow(request);
            
            _mapper.Map<ChangeUserUseCasesDto, User>(request, user);
            
            _context.SaveChanges(_actor.Id);
        }
    }
}
