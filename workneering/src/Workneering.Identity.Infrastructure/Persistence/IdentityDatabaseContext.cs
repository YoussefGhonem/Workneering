using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Workneering.Base.Domain.Interfaces;
using Workneering.Base.Helpers.Extensions;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Domain.Entities.Claims;

namespace Workneering.Identity.Infrastructure.Persistence;

public class IdentityDatabaseContext : IdentityDbContext<
      User, Role, Guid,
      UserClaim, UserRole, UserLogin,
      RoleClaim, UserToken>
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string UserId = "Id";
    private readonly Func<IHttpContextAccessor, Guid?>? _getUserId;
    public IdentityDatabaseContext()
    {
    }

    public IdentityDatabaseContext(IHttpContextAccessor httpContextAccessor, Func<IHttpContextAccessor, Guid?>? getUserId)
    {
        _httpContextAccessor = httpContextAccessor;
        _getUserId = getUserId;
    }

    public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options) : base(options)
    {

    }

    public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options, IHttpContextAccessor httpContextAccessor, Func<IHttpContextAccessor, Guid?>? getUserId) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _getUserId = getUserId;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    #region Save Changes

    public async Task<int> SaveChangesAsync(Guid? userId, CancellationToken cancellationToken = new())
    {
        CheckAndUpdateEntities(userId);
        var result = base.SaveChangesAsync(cancellationToken);
        return await result;
    }

    public int SaveChanges(Guid userId)
    {
        CheckAndUpdateEntities(userId);
        var result = base.SaveChanges();
        return result;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var userId = _getUserId?.Invoke(_httpContextAccessor) ??
                     GetClaimValue(_httpContextAccessor, UserId).ToGuidOrNull();
        CheckAndUpdateEntities(userId);
        var result = base.SaveChangesAsync(cancellationToken);
        return await result;
    }

    public override int SaveChanges()
    {
        var userId = _getUserId?.Invoke(_httpContextAccessor) ??
                     GetClaimValue(_httpContextAccessor, UserId).ToGuidOrNull();
        CheckAndUpdateEntities(userId);
        var result = base.SaveChanges();
        return result;
    }

    #endregion

    #region Helper Methods
    private void CheckAndUpdateEntities(Guid? userId)
    {
        ChangeTracker
            .Entries<ICreatedAuditableEntity>()
            .Where(e => e.State == EntityState.Added)
            .ToList().ForEach(entry => { entry.Entity.MarkAsCreated(userId); });
        ChangeTracker
            .Entries<IModifiedAuditableEntity>()
            .Where(e => e.State == EntityState.Modified)
            .ToList().ForEach(entry => { entry.Entity.MarkAsModified(userId); });
        ChangeTracker
            .Entries<ISoftDelete>()
            .Where(e => e.State is EntityState.Added or EntityState.Deleted)
            .ToList().ForEach(entry =>
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.MarkAsNotDeleted();
                else
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.MarkAsDeleted(userId);
                }
            });
    }

    private static string GetClaimValue(IHttpContextAccessor accessor, string key)
    {
        var user = accessor?.HttpContext?.User;
        if (user?.Identity is null || !user.Identity.IsAuthenticated) return null;

        var value = user.Claims.FirstOrDefault(x => x.Type == key)?.Value;
        return value;
    }

    #endregion
    public DbSet<Message> Messages => Set<Message>();
}