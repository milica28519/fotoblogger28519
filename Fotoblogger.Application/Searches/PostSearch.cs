using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Searches
{
    public class PostSearch : PhotoSearch
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
