using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Workneering.Base.Infrastructure.Persistence;

namespace Workneering.Message.Infrustructure.Persistence;

public class MessagesDbContext : ApplicationDbContext
{
    public MessagesDbContext(DbContextOptions<MessagesDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Message.Domain.Entities.Message> Messages => Set<Message.Domain.Entities.Message>();
}