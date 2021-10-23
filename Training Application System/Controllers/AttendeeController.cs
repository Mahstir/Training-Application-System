using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training_Application_System.Models;

namespace Training_Application_System.Controllers
{
    public class AttendeeController : Controller
    {
        private ApplicationDbContext _context;

        public AttendeeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            return View("AttendeeForm");
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
        public ActionResult Save(Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return View("AttendeeForm", attendee);
            }
            if (attendee.Id == 0)
            _context.Attendees.Add(attendee);
            else
            {
                var attendeeInDB = _context.Attendees.Single(a => a.Id == attendee.Id);
                TryUpdateModel(attendeeInDB);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Attendee");
        }
    }
}
       
