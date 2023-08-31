using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Workneering.Base.Infrastructure.Extension;
public static class HealthCheckBuilderExtension
{
    public static IHealthChecksBuilder AddSQLServerHealthChecks(this IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration)
    {
        healthChecksBuilder.AddSqlServer(configuration.GetConnectionString("DefaultConnection"),
            name: "sqlserver-check",
            tags: new string[] { "database" });
        return healthChecksBuilder;
    }
}
