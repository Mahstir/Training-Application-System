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

        [Min24HrsBeforeTraining]
        public IEnumerable<Training> Trainings { get; set; }

        public int TrainingId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

       

        public string TrainingName { get; set; }
    }
}