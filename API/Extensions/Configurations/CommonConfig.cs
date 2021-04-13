using Application.Interfaces;
using Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Configurations
{
    public class CommonConfig : IConfigurable
    {
        public void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserAccessor, UserAccessor>();
        }
    }
}