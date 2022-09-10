using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitTestHelperLibrary.Services;

namespace UnitTestHelperLibrary
{
    public abstract class UnitTestCore
    {
        protected static IServiceCollection ServiceCollection { get; set; }
        protected static IServiceProvider ServiceProvider { get; private set; }

        public UnitTestCore()
        {
        }

        public virtual void Setup()
        {
            InitialiseServiceCollection();
        }

        protected void InitialiseServiceProvider()
        {
            if(ServiceProvider == null)
            {
                ServiceProvider = ServiceCollection.BuildServiceProvider();
            }
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

        /*
         *  override AddServices to include any application specific services such as IDbContextFactories 
         */
        protected virtual void AddServices()
        {
            ServiceCollection.AddLogging();
        }

        protected IDbContextFactory<TContext> GetDbContextFactory<TContext>() where TContext : DbContext
        {
            var dbFactory = ServiceProvider.GetService<IDbContextFactory<TContext>>();
            return dbFactory;
        }


    }
}
