using Fotoblogger.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fotoblogger.Domain.Entities
{
    public class Photo : Entity
    {
        public static string PhotoFolderPath { get; } = "images/photos";
        public static string ThumbnailPhotoFolderPath { get; } = PhotoFolderPath + "/thumbnail";
        public string Caption { get; set; }
        public string FileName { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<UserPhotoScore>? UserPhotoScores { get; set; }
        public double? getAverageScore()
        {
            if (UserPhotoScores == null || UserPhotoScores.Count == 0)
                return null;

            return UserPhotoScores.Average(v => (double)v.Score);
        }
        public string getPhotoPath()
        {
            return PhotoFolderPath + "/" + this.FileName;
        }
        public string getThumbnailPhotoPath()
        {
            return ThumbnailPhotoFolderPath + "/" + this.FileName;
        }
    }
}
