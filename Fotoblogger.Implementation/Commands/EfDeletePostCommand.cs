using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
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
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;

        public EfDeletePostCommand(FotobloggerContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 10;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(int id)
        {
            var post = _context.Posts.Include(p => p.Photo).FirstOrDefault(p => p.Id == id);

            if (post == null)
                throw new EntityNotFoundException(id, typeof(Post));

            // only user with admin or moderator type can delete other user's posts
            if (post.CreatedBy != _actor.Id && _actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "You can only delete posts created by you.");

            post.Photo.IsDeleted = true;
            post.IsDeleted = true;

            _context.SaveChanges(_actor.Id);
        }
    }
}
