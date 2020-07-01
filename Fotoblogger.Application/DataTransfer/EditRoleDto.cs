using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class EditRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleType RoleType { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
