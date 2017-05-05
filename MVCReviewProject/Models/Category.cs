using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCReviewProject.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        //Island is the name of the island where the activity took place
        //Nickname is the nickname of the island
        //Info is general info about the island including popular activities and sites

        [Display(Name ="Hawaiian Island")]
        public string Island { get; set; }
        public string Nickname { get; set; }
        [Display(Name = "General Information")]
        public string Info { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}