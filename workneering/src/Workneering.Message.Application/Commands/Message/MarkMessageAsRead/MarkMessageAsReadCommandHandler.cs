using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Message.Domain.Entities;

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
            var message = await messagesDbContext.Messages.FirstOrDefaultAsync(x => x.Id == request.MessageId);

            message.MarkMessageAsRead();
            messagesDbContext.Messages.Attach(message);
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}