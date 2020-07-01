using Fotoblogger.Domain;
using Fotoblogger.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class UserPermissionsDto
    {
        public int UserId { get; set; }
        public RoleDto Role { get; set; }
        public IEnumerable<UseCaseDto> AllowedUseCases { get; set; }
    }
}
