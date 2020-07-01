using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class Comment : Entity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public int? ParentId { get; set; }
        public virtual Comment? ParentComment { get; set; }
        public virtual ICollection<Comment>? ChildComments { get; set; }
        public virtual ICollection<UserCommentVote>? UserCommentVotes { get; set; }
    }
}
