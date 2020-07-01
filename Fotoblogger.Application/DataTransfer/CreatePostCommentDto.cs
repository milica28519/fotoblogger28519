using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class CreatePostCommentDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }
    }
}
