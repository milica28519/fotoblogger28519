using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PhotoCaption { get; set; }
        public IFormFile Photo { get; set; }
    }
}
