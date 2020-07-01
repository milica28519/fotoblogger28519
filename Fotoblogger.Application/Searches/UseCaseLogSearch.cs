using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int UseCaseId { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public string Actor { get; set; }
    }
}
