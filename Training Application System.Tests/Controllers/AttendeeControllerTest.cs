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

        [TestMethod]
        public void TestTempData()
        {
            var controller = new AttendeeController();

            var testCheck = controller.TempData.ContainsValue("SuccessMessage");
            Assert.IsTrue(testCheck);
        }

        [TestMethod]
        public void TestListView()
        {
            var controller = new AttendeeController();

            var modelCheck = controller.ModelState.IsValid;

            Assert.IsFalse(modelCheck);
        }
    }
}
