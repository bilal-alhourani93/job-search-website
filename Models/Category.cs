using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_search.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نوع الوظيفة")]
        public string Categoryname { get; set; }
        [Required]
        [Display(Name = "وصف النوع")]
        public string CategoryDescription { get; set; }
        public virtual ICollection<Jobs>Jobss{ get; set; }
    }
}