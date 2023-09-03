using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Workneering.Base.Infrastructure.Persistence;
using Workneering.Settings.Domain.Entities;

namespace Workneering.Settings.Infrastructure.Persistence;

public class SettingsDbContext : ApplicationDbContext
{


    public SettingsDbContext(DbContextOptions<SettingsDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Country> Countries => Set<Country>();
}