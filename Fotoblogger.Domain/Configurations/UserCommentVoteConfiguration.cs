using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class UserCommentVoteConfiguration : IEntityTypeConfiguration<UserCommentVote>
    {
        public void Configure(EntityTypeBuilder<UserCommentVote> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.CommentId } );

            builder.Property(uc => uc.UserId).IsRequired();
            builder.Property(uc => uc.CommentId).IsRequired();

            builder.HasOne(uuc => uuc.User)
                .WithMany(u => u.UserCommentVotes)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(uuc => uuc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(uc => uc.Comment)
                .WithMany(c => c.UserCommentVotes)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(uc => uc.CommentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
