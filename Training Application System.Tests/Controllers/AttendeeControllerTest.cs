using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Training_Application_System.Controllers;

namespace Training_Application_System.Tests.Controllers
{
    [TestClass]
    public class AttendeeControllerTest
    {
        [TestMethod]
        public void TestAttendeeControllerDetails()
        {
            var controller = new AttendeeController();
            var result = controller.Edit(1) as ActionResult;
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void TestListView()
        //{
        //    var controller = new TrainingController();
        //    var result = controller.Edit(1) as ActionResult;
        //    Assert.IsNotNull(result);
        //}
    }
}
