using System;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTestHelperLibrary.Services
{
    public class ServiceCollectionFactory
    {

        public static IServiceCollection Create()
        {
            var serviceCollection = new ServiceCollection();
            return serviceCollection;
        }
    }
}
