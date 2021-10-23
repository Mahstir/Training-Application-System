using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_Application_System.Models;

namespace Training_Application_System.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Training

        private ApplicationDbContext _context;

        public TrainingController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var trainings = _context.Trainings.ToList();
            return View(trainings);
        }

        public ActionResult New()
        {
            return View("TrainingForm");
        }

        public ActionResult Edit(int id)
        {
            var training = _context.Trainings.FirstOrDefault(m => m.Id == id);

            if (training == null)
                return HttpNotFound();

            return View("TrainingForm", training);
        }

        [HttpPost]
        public ActionResult Save(Training training)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("TrainingForm", training);
            //}

            if (training.Id == 0)
                _context.Trainings.Add(training);
            else
            {
                var trainingInDb = _context.Trainings.Single(m => m.Id == training.Id);
                TryUpdateModel(trainingInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Training");

        }


    }
}