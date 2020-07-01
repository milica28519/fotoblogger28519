using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            // removed because if users are deleted with soft delete, so validators will handle uniquness within non-deleted users 
            //builder.HasAlternateKey(u => u.Username);

            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.UserPhotoScores)
                .WithOne()
                .HasForeignKey(uis => uis.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserCommentVotes)
                .WithOne(ucv => ucv.User)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(ucv => ucv.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UseCases)
                .WithOne(uc => uc.User)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
