using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.User.Application;
using Workneering.User.Infrastructure;
using Workneering.User.Infrastructure.Persistence;


namespace Workneering.User.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUserApplication();
            services.AddUserInfrastructure(configuration);
            services.AddScoped<UserDatabaseContext>();
            services.AddHealthChecks().AddDbContextCheck<UserDatabaseContext>();

            return services;
        }
    }
}