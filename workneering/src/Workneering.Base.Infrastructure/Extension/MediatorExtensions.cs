using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Domain.Common;

namespace Workneering.Base.Infrastructure.Extension;

public static class MediatorExtensions
{
    // With this code, you dispatch / fire the entity domain events to their respective event handlers.
    // 
    public static async Task DispatchDomainEvents(this IMediator mediator, DbContext context)
    {
        var entities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
