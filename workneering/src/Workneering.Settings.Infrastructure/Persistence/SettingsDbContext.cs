using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Workneering.Base.Infrastructure.Persistence;
using Workneering.Settings.Domain.Entities;
using Workneering.Settings.Domain.Entities.Refrences;

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
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Industry> Industries => Set<Industry>();
}