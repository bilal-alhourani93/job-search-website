using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_search.Models
{
    public class JobsViewModelByGroup
    {
        public string jobTitle { get; set; }
        public IEnumerable<ApplyForJob>Items { get; set; }
}
}