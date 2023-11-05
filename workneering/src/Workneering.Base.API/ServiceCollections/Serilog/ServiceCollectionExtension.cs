using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Workneering.Base.API.ServiceCollections.Serilog;
public static class ServiceCollectionExtension
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, ILoggingBuilder loggingBuilder)
    {
        var logger = new LoggerConfiguration()
             .ReadFrom.Configuration(builder.Configuration)
             .Enrich.FromLogContext()
          .CreateLogger();
        // builder.Host.UseSerilog();
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(logger);
        return builder;
    }
    public static WebApplication UseHealthCheckApplication(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        return app;
    }
}