using Application.Activities.Get;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Configurations
{
    public class MediatRConfig : IConfigurable
    {
        public void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(GetAllHandler).Assembly);
        }
    }
}
