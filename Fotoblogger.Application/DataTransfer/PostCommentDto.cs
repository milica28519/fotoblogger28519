using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class PostCommentDto : EntityDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int RepliesCount { get; set; }
    }
}
