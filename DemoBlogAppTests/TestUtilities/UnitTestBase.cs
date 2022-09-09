using System;
using System.Collections.Generic;
using System.Text;
using DemoBlogApp.Controllers;
using DemoBlogApp.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace DemoBlogAppTests.TestUtilities
{
    public class UnitTestBase
    {
        protected ILogger<HomeController> HomeLogger { get; set; }
        protected IDbContextFactory<DemoBlogContext> dbContextFactory { get; set; }

        public virtual void Setup()
        {
            InitaliseLoggers();
            InitialseDatabaseFactory();
        }

        private void InitialseDatabaseFactory()
        {
            var mockDbContextFactory = new Mock<IDbContextFactory<DemoBlogContext>>();
            dbContextFactory = mockDbContextFactory.Object;
        }

        private void InitaliseLoggers()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            HomeLogger = mockLogger.Object;
        }

        public virtual void Cleanup()
        { }
    }
}
