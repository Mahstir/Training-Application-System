using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Training_Application_System.Models;

namespace Training_Application_System.Controllers.API
{
    public class TrainingsController : ApiController
    {
        private ApplicationDbContext _context;

        public TrainingsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Training> GetTrainings()
        {
            return _context.Trainings.ToList();
        }

        public Training GetTraining(int id)
        {
            var training = _context.Trainings.SingleOrDefault(c => c.Id == id);

            if (training == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return training;
        }

        [HttpPost]
        public Training CreateTraining(Training training)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Trainings.Add(training);
            _context.SaveChanges();

            return training;
        }

        [HttpPut]
        public void UpdateTraining(int id, Training training)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var trainingInDb = _context.Trainings.SingleOrDefault(c => c.Id == id);

            if (trainingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            trainingInDb.Capacity = training.Capacity;
            trainingInDb.Name = training.Name;
            trainingInDb.Duration = training.Duration;
            trainingInDb.Date = training.Date;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteTraining(int id)
        {
            var trainingInDb = _context.Trainings.SingleOrDefault(c => c.Id == id);

            if (trainingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Trainings.Remove(trainingInDb);
            _context.SaveChanges();

        }
    }
}
