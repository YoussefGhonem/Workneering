using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace Workneering.Packages.Serilog;

public static class ConfigureService
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var _loggrer = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration).Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.AddSerilog(_loggrer);
        return builder;
    }

    private static IServiceCollection UseSerilog(this IServiceCollection services,
        IConfiguration configuration)
    {
    }
}