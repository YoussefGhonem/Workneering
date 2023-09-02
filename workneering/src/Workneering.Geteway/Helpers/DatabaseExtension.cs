using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Settings.Infrastructure.Persistence;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.Geteway.Helpers;
public static class DatabaseExtension
{

    public static async Task MigrateDatabase(this IServiceScope scope)
    {
        var hostingEnvironment = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();

        var identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityDatabaseContext>();
        await identityDbContext.Database.MigrateAsync();

        var userDbContext = scope.ServiceProvider.GetRequiredService<UserDatabaseContext>();
        await userDbContext.Database.MigrateAsync();

        var SettingsDbContext = scope.ServiceProvider.GetRequiredService<SettingsDbContext>();
        await SettingsDbContext.Database.MigrateAsync();
    }

    public static async Task SeedDatabase(this IServiceScope scope)
    {
        var hostingEnvironment = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();

        var identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityDatabaseContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Identity.Domain.Entities.User>>();
        await IdentityDbContextSeed.SeedDataAsync(identityDbContext, userManager);

        var SettingsDbContext = scope.ServiceProvider.GetRequiredService<SettingsDbContext>();
        await SettingsDbContextSeed.SeedDataAsync(SettingsDbContext, hostingEnvironment);
    }
}