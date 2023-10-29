using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Workneering.Base.Domain.Interfaces;
using Workneering.Base.Infrastructure.Extension;

namespace Workneering.Base.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    //private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    //public ApplicationDbContext(DbContextOptions options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    //{
    //    _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    //}
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor, IMediator mediator = default) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    }
    #region override methods
    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    // Dispatch Domain Events collection.
    //    // Choices:
    //    // A) Right BEFORE committing data (EF SaveChanges) into the DB. This makes
    //    // a single transaction including side effects from the domain event
    //    // handlers that are using the same DbContext with Scope lifetime
    //    // B) Right AFTER committing data (EF SaveChanges) into the DB. This makes
    //    // multiple transactions. You will need to handle eventual consistency and
    //    // compensatory actions in case of failures.

    //    // After this line runs, all the changes (from the Command Handler and Domain
    //    // event handlers) performed through the DbContext will be committed
    //    return await base.SaveChangesAsync(cancellationToken);
    //}
    // Within OnModelCreating, you can define entity configurations, relationships, indexes,
    // table mappings, and other aspects of the database schema, apply Fluent API configurations or data annotations to the entities in your model.
    // used for defining the model configuration and mapping entities to the database schema. 
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // to read configuration from any Infrastructure 
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        // to get not deleted in query
        builder.GetOnlyNotDeletedEntities();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }


    #endregion

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

        CheckAndUpdateEntities();
        var result = base.SaveChangesAsync(cancellationToken);
        return await result;
    }

    public override int SaveChanges()
    {

        CheckAndUpdateEntities();
        var result = base.SaveChanges();
        return result;
    }

    #endregion

    #region Helper Methods
    private async Task CheckAndUpdateEntities(Guid? userId = null)
    {
        await _mediator.DispatchDomainEvents(this);

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

}
