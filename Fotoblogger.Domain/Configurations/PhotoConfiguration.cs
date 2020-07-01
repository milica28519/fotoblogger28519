using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Caption)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.FileName).IsRequired();

            builder.HasOne(p => p.Post)
                .WithOne(p => p.Photo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.UserPhotoScores)
                .WithOne()
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(s => s.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
