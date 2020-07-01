﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class RoleUseCase
    {
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }
        public virtual Role Role { get; set; }
        public virtual UseCase UseCase { get; set; }
    }
}
