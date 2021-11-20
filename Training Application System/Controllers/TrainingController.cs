using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_Application_System.Models;
using Training_Application_System.ViewModels;

namespace Training_Application_System.Controllers
{

    /* The Training Controller Class inherits from the Controller class that is defined by ASP.NET MVC
     The class contains methods for mapping requests by clients back to the server and, response from the
    server to the client.*/
    public class TrainingController : Controller
    {

        private ApplicationDbContext _context;

        public TrainingController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult AttendeeForm(int? id) //This method is called an action in ASP.NET an it returns the AttendeeForm View to the Client. It takes a nullable int argument.
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

        public ActionResult Index() // This action returns a list of trainings to the Client or View
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

        /*The Edit action of the training controller takes an argument of the Id of the training to be edited
        checks if the record is valid and returns a training form containing details of the record. At this point
        the record is not updated yet. */
        public ActionResult Edit(int id)
        {
            var training = _context.Trainings.FirstOrDefault(m => m.Id == id);

            if (training == null)
                return HttpNotFound();

            return View("TrainingForm", training);
        }



        [HttpPost]
        /*The Save action takes a Training model as an argument and checks if the training id is 0.
         If it is, it adds a new training to the database otherwise it updates the training in the DB that 
        has the Training ID passed from the Client. */
        public ActionResult Save(Training training)
        {  

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