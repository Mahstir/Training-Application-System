using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Training_Application_System.Controllers;


namespace Training_Application_System.Tests.Controllers
{
    [TestClass]
    public class TrainingControllerTest
    {
      

        [TestMethod]
        public void TestTrainingControllerDetails()
        {
            var controller = new TrainingController();
            var result = controller.Details(1) as ActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestListView()
        {
            var controller = new TrainingController();
            var result = controller.Edit(1) as ActionResult;
            Assert.IsNotNull(result);
        }
    }
}
