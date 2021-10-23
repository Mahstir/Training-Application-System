using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Training_Application_System.Models;

namespace Training_Application_System.Controllers.API
{
    public class AttendeesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendeesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetAttendees()
        {
            var attendees = _context.Attendees.ToList();

            return Ok(attendees);
        }

        public IHttpActionResult GetAttendee(int id)
        {
            var attendee = _context.Attendees.SingleOrDefault(c => c.Id == id);

            if (attendee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(attendee);
        }

        [HttpPost]
        public Attendee CreateAttendee(Attendee attendee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Attendees.Add(attendee);
            _context.SaveChanges();

            return attendee;
        }

        [HttpPut]
        public void UpdateAttendee(int id, Attendee attendee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var attendeeInDb = _context.Attendees.SingleOrDefault(c => c.Id == id);

            if(attendeeInDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

            attendeeInDb.FirstName = attendee.FirstName;
            attendeeInDb.LastName = attendee.LastName;
            attendeeInDb.EmailAddress = attendee.EmailAddress;
            attendeeInDb.PhoneNumber = attendee.PhoneNumber;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteAttendee(int id)
        {
            var attendeeInDb = _context.Attendees.SingleOrDefault(c => c.Id == id);

            if (attendeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Attendees.Remove(attendeeInDb);
            _context.SaveChanges();

        }
    } }
    
