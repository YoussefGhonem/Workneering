using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Identity.Application;
using Workneering.Identity.Infrastructure;
using Workneering.User.Application;

namespace Workneering.Identity.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddIdentityExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityApplication(configuration);
            services.AddIdentityInfrastructure(configuration);
            services.AddScoped<IdentityDbContext>();
            services.AddHealthChecks().AddDbContextCheck<IdentityDbContext>();

            return services;
        }
    }
}