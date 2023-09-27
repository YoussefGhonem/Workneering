using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Packages.Storage.AWS3.Services;

namespace Workneering.Packages.Storage.AWS3;
public static class ConfigureServices
{
    public static IServiceCollection AddAmazonS3(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IStorageService, StorageService>();

        return services;
    }
}
