using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class DeletePostCommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
    }
}
