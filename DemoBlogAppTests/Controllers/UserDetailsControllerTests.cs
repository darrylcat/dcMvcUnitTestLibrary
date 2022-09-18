﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoBlogApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using DemoBlogAppTests.TestUtilities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoBlogApp.Models.Database;

namespace DemoBlogApp.Controllers.Tests
{
    [TestClass()]
    public class UserDetailsControllerTests : UnitTestBase
    {

        private static UserDetailsController testObj { get; set; }


        [TestInitialize()]
        public override void Setup()
        {
            base.Setup();
            if(testObj == null)
            {
                testObj = new UserDetailsController(UserDetailsLogger, dbContextFactory);
            }
        }

        [TestCleanup()]
        public override void Cleanup()
        {
            base.Cleanup();
        }

        [TestMethod()]
        public void UserDetailsControllerTest()
        {
            Assert.IsInstanceOfType(testObj, typeof(UserDetailsController));
        }

        [TestMethod()]
        public async Task IndexTest()
        {

            var actual = await testObj.Index();
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod()]
        public async Task IndexHasUserDetailRecord()
        {
            var actual = (ViewResult)await testObj.Index();
            var model = actual.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(UserDetail));
        }

        [TestMethod()]
        public async Task IndexHasOneUserDetailsRecord()
        {
            var expected = 1;
            var actual = (ViewResult)await testObj.Index();
            var model = (ICollection<UserDetail>)actual.ViewData.Model;
            Assert.AreEqual(expected, model.Count);
        }


        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}