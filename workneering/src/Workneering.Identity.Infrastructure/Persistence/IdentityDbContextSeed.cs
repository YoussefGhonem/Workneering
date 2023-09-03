using Microsoft.AspNetCore.Identity;
using Workneering.Identity.Domain.Entities;
using Workneering.Shared.Core.Identity.Enums;
using Workneering.Base.Helpers.Extensions;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Identity.Domain.Builders;

namespace Workneering.Identity.Infrastructure.Persistence
{
    public static class IdentityDbContextSeed
    {
        public static async Task SeedDataAsync(IdentityDatabaseContext databaseContext, UserManager<User> userManager)
        {
            // seed 
            await SeedRoles(databaseContext);
            await SeedSuperAdmin(databaseContext, userManager);

            // Save changes
            await databaseContext.SaveChangesAsync();
        }

        private static async Task SeedRoles(IdentityDatabaseContext databaseContext)
        {
            if (databaseContext.Roles.Any()) return;

            var names = Enum.GetNames(typeof(RolesEnum));
            var values = (RolesEnum[])Enum.GetValues(typeof(RolesEnum));

            for (var i = 0; i < names.Length; i++)
            {
                var role = new Role(names[i], values[i].GetDescription());
                await databaseContext.Roles.AddAsync(role);
            }

            // Save changes
            await databaseContext.SaveChangesAsync();
        }

        private static async Task SeedSuperAdmin(IdentityDatabaseContext databaseContext, UserManager<User> userManager)
        {
            const string name = "Super Admin";
            const string email = "admin@gmail.com";
            const string password = "Admin@2010";
            var user = await userManager.FindByNameAsync(email);

            if (user is not null) return;

            var rolesFromDb = databaseContext.Roles.ToList();

            var newUser = new CreateUserFactory(name, email)
                .WithRoles(rolesFromDb, RolesEnum.SuperAdmin)
                .Build();

            await userManager.CreateAsync(newUser, password);
        }
    }
}