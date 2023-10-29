using MediatR;
using Workneering.User.Domain.Events;

namespace Workneering.User.Application.EventHandlers
{
    public class SendEmailAfterUpdatedEventHandler : INotificationHandler<SendEmailAfterUpdatedEvent>
    {
        public Task Handle(SendEmailAfterUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
