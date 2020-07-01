using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfDeletePostCommentCommand : IDeletePostCommentCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;

        public EfDeletePostCommentCommand(FotobloggerContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 18;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(DeletePostCommentDto request)
        {
            if (_context.Posts.Find(request.PostId) == null)
                throw new EntityNotFoundException(request.PostId, typeof(Post));

            var comment = _context.Comments.Where(c => !c.IsDeleted && c.Id == request.Id).FirstOrDefault();

            if (comment == null)
                throw new EntityNotFoundException(request.Id, typeof(Comment));

            // only user with admin or moderator type can delete other user's posts
            if (comment.CreatedBy != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "You can only delete posts created by you.");

            comment.IsDeleted = true;

            _context.SaveChanges(_actor.Id);
        }
    }
}
