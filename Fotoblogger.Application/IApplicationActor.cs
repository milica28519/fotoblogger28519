using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        RoleType RoleType { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
