using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class UseCaseConfiguration : IEntityTypeConfiguration<UseCase>
    {
        public void Configure(EntityTypeBuilder<UseCase> builder)
        {
            builder.HasKey(uc => uc.Id);
            builder.Property(uc => uc.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(uc => uc.Name).IsUnique();

            builder.Property(uc => uc.Name).HasMaxLength(100);

            builder.HasMany(uc => uc.RoleUseCases)
                .WithOne(ruc => ruc.UseCase)
                .HasPrincipalKey(uc => uc.Id)
                .HasForeignKey(ruc => ruc.UseCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(uc => uc.UserUseCases)
                .WithOne(uuc => uuc.UseCase)
                .HasPrincipalKey(uc => uc.Id)
                .HasForeignKey(uuc => uuc.UseCaseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
