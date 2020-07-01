using FluentValidation;
using Fotoblogger.Application;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class AddCommentVoteValidator : AbstractValidator<UserCommentVoteDto>
    {
        public AddCommentVoteValidator(FotobloggerContext context, IApplicationActor _actor)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must(id => Exists(context.Users.FirstOrDefault(u => !u.IsDeleted && u.IsActive && u.Id == id), id));

            RuleFor(v => v.CommentId)
                .NotEmpty()
                .Must(id => Exists(context.Comments.FirstOrDefault(u => !u.IsDeleted && u.Id == id), id));

            When(x => x.UserId != 0 && x.CommentId != 0, () => 
                {
                    RuleFor(x => x.UserId)
                        .Must((dto, id) => !IsADuplicate(context.Users.Include(u => u.UserCommentVotes).FirstOrDefault(u => u.Id == id)
                            .UserCommentVotes.Any(ucv => ucv.CommentId == dto.CommentId), _actor));
                });

            RuleFor(v => v.CommentVote)
                .NotNull()
                .IsInEnum();
        }

        private bool Exists(object obj, int id)
        {
            if(obj == null)
                throw new EntityNotFoundException(id, obj.GetType());
            return true;
        }

        private bool IsADuplicate(bool condition, IApplicationActor actor)
        {
            if (condition == true)
                throw new ActionNotRepeatableException(UseCase.getUseCase(32), actor);
            return false;
        }
    }
}
