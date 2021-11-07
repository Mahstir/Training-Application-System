using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_Application_System.Models;
using Training_Application_System.ViewModels;

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

        public ActionResult AttendeeForm(int? id)
        {

            var trainingId = _context.Trainings.SingleOrDefault(c => c.Id == id).Id;
            var trainingName = _context.Trainings.SingleOrDefault(c => c.Id == id).Name;



            var viewModel = new RandomTrainingViewModel
            {

                TrainingId = trainingId,
               
                



            };

            ViewBag.Id = trainingId;
            ViewBag.Test = trainingName;
            return View(viewModel);

        }

        public ActionResult Index()
        {
            var trainings = _context.Trainings.ToList();

            if (User.IsInRole("CanCreateTrainings"))
                return View(trainings);

            return View("ReadOnly", trainings);
            //return View(trainings);
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

        public ActionResult Delete(int id)
        {
            var training = _context.Trainings.SingleOrDefault(m => m.Id == id);

            if (training == null)
            {

            }
              

            _context.Trainings.Remove(training);
            _context.SaveChanges();

            return RedirectToAction("Index", "Training");

        
        }

        public ActionResult Details(int id)
        {
            var training = _context.Trainings.SingleOrDefault(m => m.Id == id);

            //if (training == null)
            //    throw new Exception("Record not found");

            return View(training);

        }


    }
}