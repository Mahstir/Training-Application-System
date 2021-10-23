using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_Application_System.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        public Attendee Attendee { get; set; }

        [Required]
        public Training Training { get; set; }

        public int AttendeeId { get; set; }

        public List<int> TrainingIds { get; set; }
    }
}