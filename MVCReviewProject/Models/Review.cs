using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReviewProject.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        //Author is the name of the reviewer
        //Attraction is the name of the activity or site to be reviewed
        //Date is the date the activity or site was experienced
        //Headline is a brief summary of the review
        //Comment is the review of the activity or site
        //Rating is the overall rating of the activity or site
        //Price is the price rating (1 - 5) of the activity or site
        //FileLocation is for storing the url of an image (if I can figure out how to use it!)
        //SubmissionDate is the date the review is entered

        [Display(Name = "Your Name")]
        public string Author { get; set; }
        [Display(Name = "Attraction/Hotel/Restaurant")]
        public string Attraction { get; set; }
        [Display(Name = "Date Visited")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Headline")]
        public string Headline { get; set; }
        [Display(Name = "Review")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        [Display(Name = "Overall Rating: 1-5")]
        public int Rating { get; set; }
        [Display(Name = "Price Rating: 1-5")]
        public int Price { get; set; }
        [Display(Name = "Rating (e.g., ***)")]
        public string FileLocation { get; set; }
        [Display(Name = "Today's Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> SubmissionDate { get; set; }


        //set up connections to Category and Nature model IDs

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Nature")]
        public int NatureID { get; set; }
        public virtual Nature Nature { get; set; }
    }
}