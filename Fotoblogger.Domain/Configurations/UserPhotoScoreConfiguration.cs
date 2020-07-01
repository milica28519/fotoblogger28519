using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class UserPhotoScoreConfiguration : IEntityTypeConfiguration<UserPhotoScore>
    {
        public void Configure(EntityTypeBuilder<UserPhotoScore> builder)
        {
            builder.HasKey(i => new { i.PhotoId, i.UserId });

            builder.Property(i => i.PhotoId).IsRequired();
            builder.Property(i => i.UserId).IsRequired();
            builder.Property(i => i.Score).IsRequired();
        }
    }
}
