using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;

namespace Workneering.Base.API.ServiceCollections.Serilog;
public static class ServiceCollectionExtension
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, ILoggingBuilder loggingBuilder)
    {
        //var logger = new LoggerConfiguration()
        //     .ReadFrom.Configuration(builder.Configuration)
        //     .Enrich.FromLogContext()
        //     .WriteTo.MSSqlServer(
        //        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        //        sinkOptions: new MSSqlServerSinkOptions
        //        {
        //            TableName = "dbo.Logs",
        //            AutoCreateSqlTable = true, // Creates the table if it doesn't exist
        //        })
        //  .CreateLogger();
        //// builder.Host.UseSerilog();
        //loggingBuilder.ClearProviders();
        //loggingBuilder.AddSerilog(logger);
        return builder;
    }
    public static WebApplication UseHealthCheckApplication(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        return app;
    }
}