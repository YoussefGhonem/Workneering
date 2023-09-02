using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddSettingsInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<SettingsDbContext>();

        services.AddDbContext<SettingsDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(SettingsDbContext).Assembly.FullName)));

        return services;
    }
}