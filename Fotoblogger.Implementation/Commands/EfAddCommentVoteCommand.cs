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
    public class EfAddCommentVoteCommand : IAddCommentVoteCommand
    {
        private readonly FotobloggerContext _context;
        private readonly IApplicationActor _actor;
        private readonly AddCommentVoteValidator _validator;
        private readonly IMapper _mapper;

        public EfAddCommentVoteCommand(FotobloggerContext context, IApplicationActor actor, AddCommentVoteValidator validator, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 31;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public void Execute(UserCommentVoteDto request)
        {
            request.UserId = _actor.Id;

            _validator.ValidateAndThrow(request);

            var user = _context.Users.Include(u => u.UserCommentVotes).First(u => u.Id == _actor.Id);

            if (user.UserCommentVotes.Any(uc => uc.CommentId == request.CommentId))
                throw new ActionNotRepeatableException(UseCase.getUseCase(this.Id), _actor);

            user.UserCommentVotes.Add(_mapper.Map<UserCommentVote>(request));

            _context.SaveChanges(_actor.Id);
        }
    }
}
