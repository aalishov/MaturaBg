

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaturaBg.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {

        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => 
                configuration
                            .GetConnectionString("DefaultConnection");

        public static ApplicationSetting GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSetting>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<ApplicationSetting>();
        }
    
    }
}
