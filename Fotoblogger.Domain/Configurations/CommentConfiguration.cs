using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(10000);

            builder.HasOne(c => c.ParentComment)
                .WithMany(pc => pc.ChildComments)
                .HasPrincipalKey(pc => pc.Id)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.UserCommentVotes)
                .WithOne(ucv => ucv.Comment)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(ucv => ucv.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
