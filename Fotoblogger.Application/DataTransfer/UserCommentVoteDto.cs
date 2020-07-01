using Fotoblogger.Domain;
using Fotoblogger.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class UserCommentVoteDto
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public CommentVote CommentVote { get; set; }
    }
}
