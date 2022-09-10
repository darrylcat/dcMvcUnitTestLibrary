using System;
using System.Collections.Generic;
using System.Text;
using DemoBlogApp.Controllers;
using DemoBlogApp.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTestHelperLibrary;
using UnitTestHelperLibrary.Services;

namespace DemoBlogAppTests.TestUtilities
{
    public class UnitTestBase : UnitTestCore
    {
        protected string CONNECTION_STRING = "Data Source= :memory:;Version=3;New=True;";

        protected static ILogger<HomeController> HomeLogger { get; set; }
        protected static IDbContextFactory<DemoBlogContext> dbContextFactory { get; set; }

        public override void Setup()
        {
            base.Setup();
            InitaliseLoggers();
            InitialseDatabaseFactory();
        }

        protected override void AddServices()
        {
            base.AddServices();
            // Add Application specific services
            ServiceCollection.AddDbContextFactory<DemoBlogContext>(opt =>
                    opt.UseInMemoryDatabase(CONNECTION_STRING)
                    .EnableSensitiveDataLogging()
            );
        }

        private void InitialseDatabaseFactory()
        {
            /*
            var options = GetConnectionOptions(CONNECTION_STRING); 
            var mockDbContextFactory = new Mock<IDbContextFactory<DemoBlogContext>>();
            mockDbContextFactory.Setup(f => f.CreateDbContext())
                .Returns(new DemoBlogContext(options));
            dbContextFactory = mockDbContextFactory.Object; */
            dbContextFactory = GetDbContextFactory<DemoBlogContext>(); 
        }

        private void InitaliseLoggers()
        {
            var factory = ServiceProvider.GetService<ILoggerFactory>();
            HomeLogger = factory.CreateLogger<HomeController>();
        }

        public virtual void Cleanup()
        { }
    }
}
