using Fotoblogger.Domain;
using Fotoblogger.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class SetUserProfilePhotoDto
    {
        public int Id { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}
