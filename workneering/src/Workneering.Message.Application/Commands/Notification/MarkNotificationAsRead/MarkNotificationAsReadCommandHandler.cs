using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Commands.Notification.MarkNotificationAsRead
{
    public class MarkNotificationAsReadCommandHandler : IRequestHandler<MarkNotificationAsReadCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;

        public MarkNotificationAsReadCommandHandler(IMediator mediator, MessagesDbContext identityDatabase)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
        {
            var query = await messagesDbContext.Notifications.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            query!.MarkAsRead();
            messagesDbContext.Notifications.Attach(query);
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}