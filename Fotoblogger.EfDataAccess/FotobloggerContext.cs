using Fotoblogger.Domain;
using Fotoblogger.Domain.Configurations;
using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fotoblogger.EfDataAccess
{
    public class FotobloggerContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // populate DB with basic data
            // initiate UseCases from the dictionary so they exist in Database and can be accessed from Commands
            foreach (KeyValuePair<int, string> kvp in UseCase.UseCaseDictionary)
            {
                modelBuilder.Entity<UseCase>().HasData(new UseCase { Id = kvp.Key, Name = kvp.Value });
            }
            // roles
            var roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    CreatedAt = DateTime.UtcNow,
                    Name = "Administrator",
                    //IsMaster = true
                },
                new Role
                {
                    Id = 2,
                    CreatedAt = DateTime.UtcNow,
                    Name = "Moderator"
                },
                new Role
                {
                    Id = 3,
                    CreatedAt = DateTime.UtcNow,
                    Name = "User"
                }
            };
            modelBuilder.Entity<Role>().HasData(roles);
            // Users
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    FirstName = "Mika",
                    LastName = "Mikic",
                    Username = "admin",
                    Password = "admin123",
                    Email = "mika@nesto.com",
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    FirstName = "Laza",
                    LastName = "Lazic",
                    Username = "laza",
                    Password = "laza123",
                    Email = "laza@nesto.com",
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    FirstName = "Jovana",
                    LastName = "Jovanovic",
                    Username = "jovana",
                    Password = "jovana123",
                    Email = "jovana@nesto.com",
                    RoleId = 3
                }
            };
            modelBuilder.Entity<User>().HasData(users);

            // configurations
            modelBuilder.ApplyConfiguration(new RoleUseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new UserUseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseLogConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
            modelBuilder.ApplyConfiguration(new UserPhotoScoreConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserCommentVoteConfiguration());

            // global query filters
            modelBuilder.Entity<Role>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Post>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Photo>().HasQueryFilter(e => !e.IsDeleted);
        }

        public int SaveChanges(int actorId)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedBy = actorId;
                            break;
                        case EntityState.Modified:
                            if (e.IsDeleted == true && e.DeletedAt == null) //if soft delete
                                e.DeletedBy = actorId;
                            else
                                e.ModifiedBy = actorId;
                            break;
                    }
                }
            }
            return this.SaveChanges();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            break;
                        case EntityState.Modified:
                            if (e.IsDeleted == true && e.DeletedAt == null) //if soft delete
                                e.DeletedAt = DateTime.UtcNow;
                            else
                                e.ModifiedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=fotoblogger;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserPhotoScore> UserPhotoScores { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
    }
}
