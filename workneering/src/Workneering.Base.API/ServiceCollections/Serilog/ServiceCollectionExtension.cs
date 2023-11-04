using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Workneering.Base.API.ServiceCollections.Serilog;
public static class ServiceCollectionExtension
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, ILoggingBuilder loggingBuilder)
    {


        var logger = new LoggerConfiguration()
          .ReadFrom.Configuration(builder.Configuration)
          .Enrich.FromLogContext()
          .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
        return builder;
    }
    public static WebApplication UseSerilog(this WebApplication app)
    {
        // app.UseSerilogRequestLogging();
        return app;
    }
}