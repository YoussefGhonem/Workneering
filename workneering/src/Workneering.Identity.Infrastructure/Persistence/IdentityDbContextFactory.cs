using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Workneering.Identity.Infrastructure.Persistence;

public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDatabaseContext>
{
    public IdentityDatabaseContext CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");
        var config = configBuilder.Build();
        var connectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<IdentityDatabaseContext>();
        optionsBuilder.UseSqlServer(connectionString);
        var httpContextAccessor = new HttpContextAccessor();

        return new IdentityDatabaseContext(optionsBuilder.Options, httpContextAccessor, null);
    }
}