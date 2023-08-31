using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Workneering.Base.Infrastructure.Persistence;
using Workneering.Base.Infrastructure.Persistence.Interceptors;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure;

public class UserDatabaseContext : ApplicationDbContext
{
    public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Freelancer> Freelancers => Set<Freelancer>();
}