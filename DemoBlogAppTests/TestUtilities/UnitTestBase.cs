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
using UnitTestHelperLibrary.Services;

namespace DemoBlogAppTests.TestUtilities
{
    public class UnitTestBase
    {
        protected string CONNECTION_STRING = "Data Source= :memory:;Version=3;New=True;";

        protected static ILogger<HomeController> HomeLogger { get; set; }
        protected static IDbContextFactory<DemoBlogContext> dbContextFactory { get; set; }
        protected static IServiceCollection ServiceCollection { get; set; }
        protected static IServiceProvider ServiceProvider { get; private set; }

        public virtual void Setup()
        {
            InitialiseServiceCollection();
            InitaliseLoggers();
            InitialseDatabaseFactory();
        }

        private void InitialiseServiceCollection()
        {
            if (ServiceCollection == null)
            {
                ServiceCollection = ServiceCollectionFactory.Create();
                AddServices();
                InitialiseServiceProvider();
            };
        }

        private void InitialiseServiceProvider()
        {
            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        private void AddServices()
        {
            ServiceCollection.AddLogging();
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
            dbContextFactory = ServiceProvider.GetService<IDbContextFactory<DemoBlogContext>>();            
        }

        private DbContextOptions GetConnectionOptions(string connectionString)
        {
            var opt = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(connectionString)
                .EnableSensitiveDataLogging()
                .Options;
            return opt;
        }

        private void InitaliseLoggers()
        {
            // var mockLogger = new Mock<ILogger<HomeController>>();
            // HomeLogger = mockLogger.Object;
            var factory = ServiceProvider.GetService<ILoggerFactory>();
            HomeLogger = factory.CreateLogger<HomeController>();
        }

        public virtual void Cleanup()
        { }
    }
}
