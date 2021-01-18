using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace API.Extensions.Configurations
{
    public static class ConfigureServicesExtension
    {
        /// <summary>
        /// Finds all the configurable types and configures them in the Dependency Injection Container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var configurables = typeof(IConfigurable).Assembly.ExportedTypes.Where(x =>
                typeof(IConfigurable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IConfigurable>().ToList();

            configurables.ForEach(configurable => configurable.ConfigureService(services, configuration));
        }
    }
}