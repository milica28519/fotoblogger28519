using AutoMapper;
using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Email;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfEditUserCommand : IEditUserCommand
    {
        private readonly FotobloggerContext _context;
        private readonly EditUserValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EfEditUserCommand(FotobloggerContext context, EditUserValidator validator, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }
        public int Id => 23;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(EditUserDto request)
        {
            var user = _context.Users.FirstOrDefault(u => !u.IsDeleted && u.Id == request.Id);

            if (user == null)
                throw new EntityNotFoundException(request.Id, typeof(User));

            if (user.Id != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"You can only edit your own profile info.");

            _validator.ValidateAndThrow(request);

            _mapper.Map<EditUserDto, User>(request, user);

            _context.SaveChanges(_actor.Id);
        }
    }
}
