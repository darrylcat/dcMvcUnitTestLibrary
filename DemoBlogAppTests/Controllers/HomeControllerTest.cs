using System;
using DemoBlogApp.Controllers;
using DemoBlogAppTests.TestUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoBlogAppTests.Controllers
{
    [TestClass()]
    public class HomeControllerTest : UnitTestBase
    {

        private static HomeController testObj { get; set; }

        [TestInitialize()]
        public override void Setup()
        {
            base.Setup();
            if(testObj == null)
            {
                testObj = new HomeController(HomeLogger, dbContextFactory);
            }
        }

        [TestMethod()]
        public void IsObject()
        {
            Assert.IsInstanceOfType(testObj, typeof(HomeController));
        }

        [TestMethod()]
        public void ImplementsController()
        {
            Assert.IsTrue(testObj is Controller);
        }


    }
}
