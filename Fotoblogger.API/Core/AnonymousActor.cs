using Fotoblogger.Application;
using Fotoblogger.Domain;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotoblogger.API.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymous";

        public RoleType RoleType => RoleType.Administrator;

        public IEnumerable<int> AllowedUseCases => new List<int> { 1 , 28 };
        // 1 - User Regsitration
        // 28 - Activate User
    }
}
