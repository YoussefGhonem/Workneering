﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Workneering.Base.Application.Behaviors.MediatR;
using Workneering.Base.Application.Behaviors.MediatR.Caching;

namespace Workneering.Base.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddBaseApplication(this IServiceCollection services)
    {
        // This line registers validators from the executing assembly in the dependency injection container.
        // It scans the assembly for classes that implement the IValidator<T> interface and registers them.
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddMediatR(typeof(IStartup));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(IStartup).Assembly));

        // These behaviors are added to the MediatR pipeline and will be executed in the specified order when processing requests.
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCachingBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        return services;
    }
}
