using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Workneering.Message.Infrustructure.Persistence;

public class MessagesDbContextFactory : IDesignTimeDbContextFactory<MessagesDbContext>
{
    public MessagesDbContext CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");
        var config = configBuilder.Build();
        var connectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<MessagesDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        var httpContextAccessor = new HttpContextAccessor();

        return new MessagesDbContext(optionsBuilder.Options, httpContextAccessor);
    }
}