using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class RoleUseCaseConfiguration : IEntityTypeConfiguration<RoleUseCase>
    {
        public void Configure(EntityTypeBuilder<RoleUseCase> builder)
        {
            builder.HasKey(uc => new { uc.RoleId, uc.UseCaseId } );

            builder.Property(uc => uc.RoleId).IsRequired();
            builder.Property(uc => uc.UseCaseId).IsRequired();

            builder.HasOne(ruc => ruc.Role)
                .WithMany(r => r.RoleUseCases)
                .HasPrincipalKey(r => r.Id)
                .HasForeignKey(ruc => ruc.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ruc => ruc.UseCase)
                .WithMany(uc => uc.RoleUseCases)
                .HasPrincipalKey(uc => uc.Id)
                .HasForeignKey(ruc => ruc.UseCaseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
