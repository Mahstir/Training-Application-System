using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_Application_System.Models
{
  /*Training Model that contains all the properties
   which will later be created as columns on the database*/
    public class Training
    {

        public int Id { get; set; }

        [Display (Name="Training Name")]
        [Required]
        public string Name { get; set; }

        [Display (Name = "Duration in Hours")] //Display name helps to show how the fields would be displayed on the view
        [Required] //Required adds both server side and client side validation to this Model property
        public int Duration { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
    
        public DateTime Date { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0: hh:mm}")]
        public DateTime Time { get; set; }


        [Required]
        [Min24HrsBeforeTraining]
        public int Capacity { get; set; }

        public string Details { get; set; }
    }
}