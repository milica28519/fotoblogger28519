using Fotoblogger.Domain;
using Fotoblogger.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class ActivateUserDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
