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
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Commands
{
    public class EfRemoveCommentVoteCommand : IRemoveCommentVoteCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;
        private readonly ActivateUserValidator _validator;

        public EfRemoveCommentVoteCommand(FotobloggerContext context, IApplicationActor actor, ActivateUserValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }

        public int Id => 32;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(int id)
        {
            if (_context.Comments.FirstOrDefault(c => !c.IsDeleted && c.Id == id) == null)
                throw new EntityNotFoundException(id, typeof(Comment));

            //_validator.ValidateAndThrow(request);

            var user = _context.Users.Include(u => u.UserCommentVotes).First(u => u.Id == _actor.Id);

            var vote = user.UserCommentVotes.FirstOrDefault(uc => uc.CommentId == id);

            if (vote != null)
                user.UserCommentVotes.Remove(vote);

            _context.SaveChanges(_actor.Id);
        }
    }
}
