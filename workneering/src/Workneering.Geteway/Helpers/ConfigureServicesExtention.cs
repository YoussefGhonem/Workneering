﻿using Workneering.Base.API.ServiceCollections.ApiVersioning;
using Workneering.Base.API.ServiceCollections.ExceptionHandling;
using Workneering.Base.API.ServiceCollections.HealthCheckApplication;
using Workneering.Base.API.ServiceCollections.Swagger;
using Workneering.Base.Application;
using Workneering.Base.Infrastructure;
using Workneering.Identity.API;
using Workneering.User.API;

namespace Workneering.Geteway.Helpers;
public static class ConfigureServicesExtention
{
    // At run time, the ConfigureServices method is called before the Configure method.
    // It includes built-in IoC container
    public static IServiceCollection ConfigureServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        #region Appsettings & env variables
        builder.Configuration
            //  to get the current working directory of the application
            .SetBasePath(Directory.GetCurrentDirectory())
            // "appsettings.json": The name of the JSON configuration file to be read. In this case, it's "appsettings.json".
            // true: This parameter specifies if the file is optional. If set to true, the application will continue without an error if the specified file is not found.
            // true: This parameter specifies whether to reload the configuration automatically if the file is changed. If set to true, the configuration will be updated when the "appsettings.json" file is modified.
            .AddJsonFile("appsettings.json", true, true) // Try reading from appsettings
            .AddEnvironmentVariables(); //  This method fetches environment variables and adds them to the configuration.
        #endregion

        #region .Net Services
        services.AddControllersWithViews();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();
        services.AddHealthChecksUI()
                .AddInMemoryStorage();
        #endregion

        #region Base 

        services.AddBaseApplication()
                .AdBaseInfrastructure(builder.Configuration)
                .AddBaseSwagger(builder.Configuration)
                .AddApiVersioningService()
                .AddExceptionHandling()
                .AddHealthCheckApplication(builder.Configuration);

        #endregion

        #region Packages

        #region RabbitMQ
        //services.AddRabbitMQ(builder.Configuration);
        #endregion

        #endregion

        #region Solution Extensions
        services.AddIdentityExtension(builder.Configuration);
        services.AddUserExtension(builder.Configuration);
        #endregion


        return services;
    }

    // Introduced the middleware components to define a request pipeline, which will be executed on every request.
    public static async Task<WebApplication> Configure(this WebApplication app, IWebHostEnvironment env)
    {
        #region Using Base Packages

        app.UseExceptionHandling()
           .UseHealthCheckApplication()
           .UseBaseSwagger(app.Configuration);

        #endregion



        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            await scope.MigrateDatabase();
            await scope.SeedDatabase();
        }

        return app;
    }
}
