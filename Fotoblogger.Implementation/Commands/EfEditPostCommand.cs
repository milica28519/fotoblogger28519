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
    public class EfEditPostCommand : IEditPostCommand
    {
        private readonly FotobloggerContext _context;
        private readonly EditPostValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfEditPostCommand(FotobloggerContext context, EditPostValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 3;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(EditPostDto request)
        {
            var post = _context.Posts.Include(p => p.Photo).FirstOrDefault(p => p.Id == request.Id);

            if (post == null)
                throw new EntityNotFoundException(request.Id, typeof(Post));

            if (post.CreatedBy != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"You can only edit posts created by you.");

            _validator.ValidateAndThrow(request);

            _mapper.Map<EditPostDto, Post>(request, post);

            _context.SaveChanges(_actor.Id);
        }
    }
}
