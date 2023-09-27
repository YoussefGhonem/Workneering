using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Workneering.Packages.Storage.AWS3;
public static class ConfigureServices
{
    public static IServiceCollection AddAmazonS3(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
