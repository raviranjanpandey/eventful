using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace IOC.Configurations
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var configurables = typeof(IConfigurable).Assembly.ExportedTypes.Where(x =>
                typeof(IConfigurable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IConfigurable>().ToList();

            configurables.ForEach(configurable => configurable.ConfigureServices(services, configuration));
        }
    }
}
