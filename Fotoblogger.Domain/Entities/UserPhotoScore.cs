using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class UserPhotoScore
    {
        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public int Score { get; set; }
    }
}
