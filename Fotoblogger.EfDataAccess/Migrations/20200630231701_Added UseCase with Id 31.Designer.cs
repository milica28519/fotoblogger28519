﻿// <auto-generated />
using System;
using Fotoblogger.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fotoblogger.EfDataAccess.Migrations
{
    [DbContext(typeof(FotobloggerContext))]
    [Migration("20200630231701_Added UseCase with Id 31")]
    partial class AddedUseCasewithId31
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fotoblogger.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(10000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ParentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(10000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("RoleType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 23, 17, 1, 111, DateTimeKind.Utc).AddTicks(2614),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Administrator",
                            RoleType = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 23, 17, 1, 111, DateTimeKind.Utc).AddTicks(3744),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "Moderator",
                            RoleType = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 6, 30, 23, 17, 1, 111, DateTimeKind.Utc).AddTicks(3761),
                            CreatedBy = 0,
                            IsDeleted = false,
                            Name = "User",
                            RoleType = 0
                        });
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.RoleUseCase", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UseCaseId");

                    b.HasIndex("UseCaseId");

                    b.ToTable("RoleUseCase");
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.UseCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("UseCases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Get Posts"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Create Posts"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Edit Post"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Get Roles"
                        },
                        new
                        {
                            Id = 5,
                            Name = "User Registration"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Create Role"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Edit Role"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Get Role"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Delete Role"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Delete Post"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Get Post"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Get Photos"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Get Photo"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Score Photo"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Remove Score for Photo"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Add Post Comment"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Edit Post Comment"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Delete Post Comment"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Get Post Comments"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Get Post Comment Replies"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Get User"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Get Users"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Edit User"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Delete User"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Set Profile Photo"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Remove Profile Photo"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Deactivate User"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Activate User"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Change User Role"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Change User Allowed UseCases"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Get User Permissions"
                        });
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.UseCaseLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.Property<string>("UseCaseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UseCaseLogs");
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ProfilePhotoFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 23, 17, 1, 111, DateTimeKind.Utc).AddTicks(5927),
                            CreatedBy = 0,
                            Email = "mika@nesto.com",
                            FirstName = "Mika",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Mikic",
                            Password = "admin123",
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 23, 17, 1, 111, DateTimeKind.Utc).AddTicks(8826),
                            CreatedBy = 0,
                            Email = "laza@nesto.com",
                            FirstName = "Laza",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Lazic",
                            Password = "laza123",
                            RoleId = 2,
                            Username = "laza"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 6, 30, 23, 17, 1, 111, DateTimeKind.Utc).AddTicks(8900),
                            CreatedBy = 0,
                            Email = "jovana@nesto.com",
                            FirstName = "Jovana",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Jovanovic",
                            Password = "jovana123",
                            RoleId = 3,
                            Username = "jovana"
                        });
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.UserPhotoScore", b =>
                {
                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("PhotoId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhotoScores");
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.UserUseCase", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "UseCaseId");

                    b.HasIndex("UseCaseId");

                    b.ToTable("UserUseCase");
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Fotoblogger.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Fotoblogger.Domain.Entities.Comment", "ParentComment")
                        .WithMany("ChildComments")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Fotoblogger.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.Post", b =>
                {
                    b.HasOne("Fotoblogger.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Fotoblogger.Domain.Entities.Photo", "Photo")
                        .WithOne("Post")
                        .HasForeignKey("Fotoblogger.Domain.Entities.Post", "PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.RoleUseCase", b =>
                {
                    b.HasOne("Fotoblogger.Domain.Entities.Role", "Role")
                        .WithMany("RoleUseCases")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fotoblogger.Domain.Entities.UseCase", "UseCase")
                        .WithMany("RoleUseCases")
                        .HasForeignKey("UseCaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.User", b =>
                {
                    b.HasOne("Fotoblogger.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.UserPhotoScore", b =>
                {
                    b.HasOne("Fotoblogger.Domain.Entities.Photo", null)
                        .WithMany("UserPhotoScores")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fotoblogger.Domain.Entities.User", null)
                        .WithMany("UserPhotoScores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fotoblogger.Domain.Entities.UserUseCase", b =>
                {
                    b.HasOne("Fotoblogger.Domain.Entities.UseCase", "UseCase")
                        .WithMany("UserUseCases")
                        .HasForeignKey("UseCaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fotoblogger.Domain.Entities.User", "User")
                        .WithMany("UseCases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
