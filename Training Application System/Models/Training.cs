using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_Application_System.Models
{
    public class Training
    {

        public int Id { get; set; }

        [Display (Name="Training Name")]
        [Required]
        public string Name { get; set; }

        [Display (Name = "Duration in Minutes")]
        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}