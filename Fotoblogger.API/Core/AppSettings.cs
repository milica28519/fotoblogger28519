using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotoblogger.API.Core
{
    public class AppSettings
    {
        // database, e-mail and token settings
        public string DbConnectionString { get; set; }
        public string JwtSecretKey { get; set; }
        public string JwtIssuer { get; set; }
        public string EmailFrom { get; set; }
        public string EmailPassword { get; set; }
        public string ApplicationInstance { get; set; }

        // public folder settings
        public string PublicFolder { get; set; }
        public string ProfileImageFolder { get; set; }
        public string PhotoFolder { get; set; }
        public string ThumbnailPhotoFolder { get; set; }
    }
}
