using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class UseCaseLogConfiguration : IEntityTypeConfiguration<UseCaseLog>
    {
        public void Configure(EntityTypeBuilder<UseCaseLog> builder)
        {
            builder.HasKey(ucl => ucl.Id);
            builder.Property(ucl => ucl.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ucl => ucl.Date).HasDefaultValueSql("GETDATE()");
        }
    }
}
