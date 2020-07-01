using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Searches
{
    public class PostCommentRepliesSearch : PagedSearch
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
    }
}
