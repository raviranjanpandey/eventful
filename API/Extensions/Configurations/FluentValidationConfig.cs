using Application.Activities.Save;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Configurations
{
    public class FluentValidationConfig : IConfigurable
    {
        public void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidation(new[]
            {
                typeof(CreateActivityValidator).Assembly
            });
        }
    }
}
