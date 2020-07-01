using Fotoblogger.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class CreateRoleDto
    {
        public string Name { get; set; }
        public RoleType RoleType { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
