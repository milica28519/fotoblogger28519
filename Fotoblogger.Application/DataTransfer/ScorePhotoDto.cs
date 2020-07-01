using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class ScorePhotoDto
    {
        public int PhotoId { get; set; }
        public int Score { get; set; }
    }
}
