using Fotoblogger.Application;
using Fotoblogger.Domain;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotoblogger.API.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public RoleType RoleType { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
