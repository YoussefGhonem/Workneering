using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Geteway.Helpers;
public static class DatabaseExtension
{

    public static async Task MigrateDatabase(this IServiceScope scope)
    {
        var identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityDatabaseContext>();
        await identityDbContext.Database.MigrateAsync();
    }

    public static async Task SeedDatabase(this IServiceScope scope)
    {
        var identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityDatabaseContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        await IdentityDbContextSeed.SeedDataAsync(identityDbContext, userManager);
    }
}