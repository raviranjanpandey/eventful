using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Configurations
{
    public class CorsConfig : IConfigurable
    {
        public void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials().WithOrigins(new string[] { "http://localhost:3000" });
                });
            });
        }
    }
}
