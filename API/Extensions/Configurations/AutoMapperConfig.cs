using Application.Core;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Configurations
{
    public class AutoMapperConfig : IConfigurable
    {
        public void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        }
    }
}
