using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Packages.SignalR.Models;

namespace Workneering.Packages.SignalR;

public static class ConfigureService
{
    public static IServiceCollection AddSignalRApplication(this IServiceCollection services)
    {
        services.AddSignalR();

        return services;
    }

    public static WebApplication UseSignalRApplication(this WebApplication app)
    {

        app.UseEndpoints(endpoints =>
        {
            app.MapControllers();
            endpoints.MapHub<ChatHub>("/api/v1/chatHub");
        });
        return app;
    }
}