using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_search.Models
{
    public class Jobs
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="اسم الوظيفة")]
        public  string JobTitle { get; set; }

        
        [Display(Name = "وصف الوظيفة")]
        public string JobContent { get; set; }

       
        [Display(Name = "صورة الوظيفة")]
        public string JobImage { get; set; }

        
        [Display(Name = "نوع الوظيفة")]
        public int CategoryId { get; set; }
        public string userId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}