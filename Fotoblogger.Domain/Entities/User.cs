using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class User : Entity
    {
        public static string PofileImageFolderPath { get; } = "images/profile";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserUseCase>? UseCases { get; set; }
        public string? ProfilePhotoFileName { get; set; }
        public virtual ICollection<UserPhotoScore>? UserPhotoScores { get; set; }
        public virtual ICollection<UserCommentVote>? UserCommentVotes { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public string? getProfilePhotoPath()
        {
            if (this.ProfilePhotoFileName == null)
                return null;
            return PofileImageFolderPath + "/" + this.ProfilePhotoFileName;
        }
        public IEnumerable<UseCase> getAllowedUseCases()
        {
            var allowedUseCases = new List<UseCase>();

            if (this.Role != null && this.Role.RoleUseCases != null)
            {
                foreach (var item in this.Role.RoleUseCases.Select(ruc => ruc.UseCase).ToList())
                {
                    allowedUseCases.Add(item);
                }
            }
            if (this.UseCases != null)
            {
                foreach (var item in this.UseCases)
                {
                    allowedUseCases.Add(item.UseCase);
                }
            }

            return allowedUseCases.Distinct();
        }

        public IEnumerable<int> getAllowedUseCasesIds()
        {
            var allowedUseCasesIds = new List<int>();

            var allowedUseCases = this.getAllowedUseCases();
            if (allowedUseCases != null && allowedUseCases.Any())
            {
                foreach (var item in allowedUseCases)
                {
                    if( item != null )
                        allowedUseCasesIds.Add(item.Id);
                } 
            }

            return allowedUseCasesIds.ToList();
        }
    }
}
