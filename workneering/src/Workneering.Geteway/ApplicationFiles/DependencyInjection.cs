namespace Workneering.Geteway.ApplicationFiles;

public static class DependencyInjection
{
    public static IApplicationBuilder UseFileExtension(this IApplicationBuilder app)
    {
        FileExtension.InitializeConfiguration(app.ApplicationServices.GetRequiredService<IConfiguration>());
        return app;
    }
}