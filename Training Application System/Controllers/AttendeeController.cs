using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training_Application_System.Models;
using Training_Application_System.ViewModels;

namespace Training_Application_System.Controllers
{
    [Authorize]
    public class AttendeeController : Controller
    {
        private ApplicationDbContext _context;

        public AttendeeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult AttendeeForm(int? id)
        {

            var trainings = _context.Trainings.SingleOrDefault(c => c.Id == id).Id;
            

            var viewModel = new RandomTrainingViewModel
            {

                TrainingId = trainings,
             



            };
            return View(viewModel);
           
        }

        public ActionResult Index()
        {
            var attendees = _context.Attendees.ToList();

            return View(attendees);
        }

        public ActionResult Edit(int id)
        {
            var attendee = _context.Attendees.FirstOrDefault(m => m.Id == id);

            if (attendee == null)
                return HttpNotFound();

            return View("AttendeeForm", attendee);
         
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Save(Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return View("AttendeeForm", attendee);
            }

            var training = _context.Trainings.Single(m => m.Id == attendee.TrainingId);

            if (training.Capacity == 0)
                throw new Exception("You can no longer register for this training as the capacity has been met.");

            if (attendee.Id == 0)
            {
                _context.Attendees.Add(attendee);

                training.Capacity--;


            }
            else
            {
                var attendeeInDB = _context.Attendees.Single(a => a.Id == attendee.Id);
                TryUpdateModel(attendeeInDB);
            }

            _context.SaveChanges();

            TempData["SuccessMessage"] = "You have successfully registered for this training";

            return RedirectToAction("Index", "Training");
        }
    }
}
       
