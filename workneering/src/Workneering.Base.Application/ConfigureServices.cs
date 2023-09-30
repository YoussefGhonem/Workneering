using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Base.Application.Behaviors.MediatR;

namespace Workneering.Base.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddBaseApplication(this IServiceCollection services)
    {
        // This line registers validators from the executing assembly in the dependency injection container.
        // It scans the assembly for classes that implement the IValidator<T> interface and registers them.
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddMediatR(Assembly.GetExecutingAssembly());

        // These behaviors are added to the MediatR pipeline and will be executed in the specified order when processing requests.

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SecurityValidationBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ResetCacheBehaviour<,>));
        return services;
    }
}
