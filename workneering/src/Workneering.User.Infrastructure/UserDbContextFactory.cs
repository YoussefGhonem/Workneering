using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Workneering.User.Infrastructure;

public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDatabaseContext>
{
    public UserDatabaseContext CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");
        var config = configBuilder.Build();
        var connectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<UserDatabaseContext>();
        optionsBuilder.UseSqlServer(connectionString);
        var httpContextAccessor = new HttpContextAccessor();
        return new UserDatabaseContext(optionsBuilder.Options, httpContextAccessor);
    }
}