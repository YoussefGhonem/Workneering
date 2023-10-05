using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Commands.Message.MarkMessageAsRead
{
    public class MarkMessageAsReadCommandHandler : IRequestHandler<MarkMessageAsReadCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;

        public MarkMessageAsReadCommandHandler(IMediator mediator, MessagesDbContext identityDatabase)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(MarkMessageAsReadCommand request, CancellationToken cancellationToken)
        {
            var messages = messagesDbContext.Messages
                .Where(x => x.ProjectId == request.ProjectId && x.CreatedUserId != CurrentUser.Id && request.Ids.Contains(x.Id)).ToList();

            foreach (var item in messages)
            {
                item.MarkMessageAsRead();
            }
            messagesDbContext.Messages.AttachRange(messages);
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}