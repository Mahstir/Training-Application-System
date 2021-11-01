using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_Application_System.Models;
using Training_Application_System.ViewModels;


namespace Training_Application_System.Controllers
{
    public class ApplicationsFormController : Controller
    {
        private ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationsFormController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationsFormController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ApplicationsForm
        public ActionResult New()
        {
            var trainings = _context.Trainings.ToList();
            var viewModel = new Participant
            {
               
                Trainings = trainings
              
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new Participant
                {
                    User = user,
                    Trainings = _context.Trainings.ToList()

                };

                return View("New", viewModel);
            }

            var userInDb = _context.Users.Single(c => c.Id == user.Id);
            TryUpdateModel(userInDb);

            _context.SaveChanges();

            return RedirectToAction("Index", "Training");
        }


    }
}