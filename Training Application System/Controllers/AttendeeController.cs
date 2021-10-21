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
            return View();
        }

    }
}
       
