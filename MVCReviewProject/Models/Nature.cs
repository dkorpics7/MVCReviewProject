using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCReviewProject.Models
{
    public class Nature
    {
        [Key]
        public int ID { get; set; }

        //Type is the type or nature of the Attraction

        [Display(Name = "Type of Activity")]
        public string Type { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}