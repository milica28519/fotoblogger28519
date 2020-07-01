using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class UserCommentVote
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public CommentVote Vote { get; set; }
        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
    }
    public enum CommentVote
    {
        Downvote,
        Upvote
    }
}
