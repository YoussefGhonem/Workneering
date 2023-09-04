using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Workneering.Project.Infrastructure.Persistence;

public class ProjectsDbContextFactory : IDesignTimeDbContextFactory<ProjectsDbContext>
{
    public ProjectsDbContext CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");
        var config = configBuilder.Build();
        var connectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<ProjectsDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        var httpContextAccessor = new HttpContextAccessor();

        return new ProjectsDbContext(optionsBuilder.Options, httpContextAccessor);
    }
}