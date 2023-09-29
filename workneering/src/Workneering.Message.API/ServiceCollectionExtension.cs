using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Message.Application;
using Workneering.Message.Infrustructure;
using Workneering.Message.Infrustructure.Persistence;

namespace Workneering.Message.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddIdentityExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMessageApplication();
            services.AddMessageInfrastructure(configuration);
            services.AddScoped<MessagesDbContext>();
            services.AddHealthChecks().AddDbContextCheck<MessagesDbContext>();
            return services;
        }
    }
}