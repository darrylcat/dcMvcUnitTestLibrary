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
        protected static ILogger<UserDetailsController> UserDetailsLogger { get; set; }
        protected static IDbContextFactory<DemoBlogContext> dbContextFactory { get; set; }

        public override void Setup()
        {
            base.Setup();
            InitaliseLoggers();
            InitialseDatabaseFactory();
            InitialiseDatabaseRecords();
        }

        private void InitialiseDatabaseRecords()
        {
            var db = dbContextFactory.CreateDbContext();
            InitialiseUserDetails(db);
            db.SaveChanges();
            db = null;
        }

        private void InitialiseUserDetails(DemoBlogContext db)
        {
            var user1 = new UserDetail() {
                Active = true,
                Created = DateTime.Now,
                Email = "anon.mouse@example.com",
                FirstName = "Anon",
                LastName = "Mouse",
                Password = "Not.A.Real.Password",
                Salt = "qwertyuiopasdfghjklzxcvbnm123456789!@",
                Title = "Mr"
            };
            db.UserDetails.Add(user1);
            db.SaveChanges();
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
            UserDetailsLogger = factory.CreateLogger<UserDetailsController>();
        }

        public virtual void Cleanup()
        { }
    }
}
