using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Project.Infrastructure;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Project.Application;

namespace Workneering.Project.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProjectExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProjectApplication();
            services.AddProjectsInfrastructure(configuration);
            services.AddScoped<ProjectsDbContext>();
            services.AddHealthChecks().AddDbContextCheck<ProjectsDbContext>();

            return services;
        }
    }
}