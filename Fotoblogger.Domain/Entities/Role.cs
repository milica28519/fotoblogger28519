using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Fotoblogger.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public RoleType RoleType { get; set; }
        public virtual ICollection<RoleUseCase> RoleUseCases { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public enum RoleType
    {
        Anonymous, // anonymous user - unauthorized
        Administrator, // doesn't have any assigned use cases - can do everything
        Moderator, // can execute assigned use cases - with rights of admin too for the assigned use case
        User // can execute assigned use cases - can only changed things he created
    }
}
