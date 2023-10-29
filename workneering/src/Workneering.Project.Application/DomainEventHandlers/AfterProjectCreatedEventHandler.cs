using MediatR;
using Workneering.Project.Domain.Events;

namespace Workneering.Project.Application.DomainEventHandlers;
public class AfterProjectCreatedEventHandler : INotificationHandler<AfterProjectCreatedEvent>
{
    public Task Handle(AfterProjectCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
