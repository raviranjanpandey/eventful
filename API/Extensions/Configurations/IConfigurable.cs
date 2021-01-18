using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Configurations
{
    public interface IConfigurable
    {
        void ConfigureService(IServiceCollection services, IConfiguration configuration);
    }
}