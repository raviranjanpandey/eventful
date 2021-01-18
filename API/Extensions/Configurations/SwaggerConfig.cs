using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions.Configurations
{
    public class SwaggerConfig : IConfigurable
    {
        public void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Eventful", Version = "v1.0.0" });
            });
        }
    }
}