using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training_Application_System.Models;

namespace Training_Application_System.ViewModels
{
    public class RandomTrainingViewModel
    {
        public Attendee Attendee { get; set; }
        public List<Training> Trainings { get; set; }
    }
}