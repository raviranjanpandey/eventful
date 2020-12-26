using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace IOC.Configurations
{
    public class ValuesConfig : IConfigurable
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IValuesRepository, ValuesRepository>();
        }
    }
}
