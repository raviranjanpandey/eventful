using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.Configurations
{
    public interface IConfigurable
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
