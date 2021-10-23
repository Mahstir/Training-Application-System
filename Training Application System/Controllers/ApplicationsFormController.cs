using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Training_Application_System.Controllers
{
    public class ApplicationsFormController : Controller
    {
        // GET: ApplicationsForm
        public ActionResult New()
        {
            return View("ApplicationForm");
        }
    }
}