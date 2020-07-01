using AutoMapper;
using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
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
    public class EfEditPostCommentCommand : IEditPostCommentCommand
    {
        private readonly FotobloggerContext _context;
        private readonly EditPostCommentValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfEditPostCommentCommand(FotobloggerContext context, EditPostCommentValidator validator, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 17;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(EditPostCommentDto request)
        {
            if (_context.Posts.Find(request.PostId) == null)
                throw new EntityNotFoundException(request.PostId, typeof(Post));

            var comment = _context.Comments.Where(c => !c.IsDeleted && c.Id == request.Id).FirstOrDefault();

            if (comment == null)
                throw new EntityNotFoundException(request.Id, typeof(Comment));

            if (comment.CreatedBy != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, $"You can only edit comments created by you.");

            _validator.ValidateAndThrow(request);

            _mapper.Map<EditPostCommentDto,Comment>(request, comment);

            _context.SaveChanges(_actor.Id);
        }
    }
}
