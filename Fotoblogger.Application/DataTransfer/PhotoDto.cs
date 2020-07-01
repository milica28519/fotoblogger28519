using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.DataTransfer
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string ThumbnailPath { get; set; }
        public double? AverageScore { get; set; }
    }
}
