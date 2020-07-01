using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string? Text { get; set; }
        public int PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
