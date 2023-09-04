using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddSettingsInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ProjectsDbContext>();

        services.AddDbContext<ProjectsDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ProjectsDbContext).Assembly.FullName)));

        return services;
    }
}