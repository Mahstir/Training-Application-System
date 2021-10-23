using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Training_Application_System.Models;

namespace Training_Application_System.Controllers
{
    public class ApplicationsController : ApiController
    {
        private ApplicationDbContext _context;

        public ApplicationsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewApplication(Application application)
        {
            var attendee = _context.Attendees.Single(c => c.Id == application.AttendeeId);

            var trainings = _context.Trainings.Where(c => application.TrainingIds.Contains(c.Id));

            foreach(var training in trainings)
            {
                if (training.Capacity == 0)
                    return BadRequest("This training is no longer available as it has met capacity");

                training.Capacity--;

                var registration = new Application()
                { 
                    Attendee = attendee,
                    Training = training
                };
                _context.Applications.Add(registration);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
