using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Workneering.Base.Infrastructure.Persistence;

namespace Workneering.Project.Infrastructure.Persistence;

public class ProjectsDbContext : ApplicationDbContext
{
    public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Domain.Entities.Project> Projects => Set<Domain.Entities.Project>();
}