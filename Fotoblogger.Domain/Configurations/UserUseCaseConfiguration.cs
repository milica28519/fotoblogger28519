using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class UserUseCaseConfiguration : IEntityTypeConfiguration<UserUseCase>
    {
        public void Configure(EntityTypeBuilder<UserUseCase> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.UseCaseId } );

            builder.Property(uc => uc.UserId).IsRequired();
            builder.Property(uc => uc.UseCaseId).IsRequired();

            builder.HasOne(uuc => uuc.User)
                .WithMany(u => u.UseCases)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(uuc => uuc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(uuc => uuc.UseCase)
                .WithMany(uc => uc.UserUseCases)
                .HasPrincipalKey(uuc => uuc.Id)
                .HasForeignKey(ruc => ruc.UseCaseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
