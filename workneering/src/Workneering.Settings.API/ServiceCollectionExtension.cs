using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Settings.Application;
using Workneering.Settings.Infrastructure;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSettingsExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationSettings();
            services.AddSettingsInfrastructure(configuration);
            services.AddScoped<SettingsDbContext>();
            services.AddHealthChecks().AddDbContextCheck<SettingsDbContext>();

            return services;
        }
    }
}