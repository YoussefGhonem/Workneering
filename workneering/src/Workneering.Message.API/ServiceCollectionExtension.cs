using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Workneering.Message.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddIdentityExtension(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }
    }
}