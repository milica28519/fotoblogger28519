using FluentValidation;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Validators
{
    public class CreatePostCommentValidator : AbstractValidator<CreatePostCommentDto>
    {
        public CreatePostCommentValidator(FotobloggerContext context)
        {
            RuleFor(c => c.PostId)
                .NotEmpty();

            When(c => c.PostId != 0, () =>
            {
                RuleFor(c => c.PostId)
                    .Must(postId => context.Posts.Any(p => p.Id == postId))
                    .WithMessage($"Post you are trying to add comment on doesn't exist.");
            });

            RuleFor(c => c.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(c => c.Text)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(10000);

            When(c => c.ParentId != null && c.ParentId != 0, () =>
                {
                    RuleFor(c => c.ParentId)
                        .Must(parentCommentId => context.Comments.Any(p => p.Id == parentCommentId))
                        .WithMessage($"Comment you are trying to reply to doesn't exist.");
                }
            );
        }
    }
}
