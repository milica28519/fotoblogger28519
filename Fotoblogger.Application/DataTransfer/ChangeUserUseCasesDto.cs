using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class ChangeUserUseCasesDto
    {
        public int UserId { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
