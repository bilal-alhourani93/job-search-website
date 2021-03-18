using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_search.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public string Massage { get; set; }
        public DateTime ApplyDate { get; set; }
        public int jobsId { get; set; }
        public string userId { get; set; }

        public virtual Jobs jobs { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}