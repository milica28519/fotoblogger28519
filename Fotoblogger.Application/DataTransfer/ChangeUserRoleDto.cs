using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class ChangeUserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
