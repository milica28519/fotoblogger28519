using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoleType { get; set; }
        public IEnumerable<UseCaseDto> AllowedUseCases { get; set; }
    }
}
