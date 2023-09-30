using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Message.Infrustructure.Persistence;

namespace Workneering.Message.Application.Commands.Message.DeleteMessage
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;

        public DeleteMessageCommandHandler(IMediator mediator, MessagesDbContext identityDatabase)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await messagesDbContext.Messages.FirstOrDefaultAsync(x => x.Id == request.MessageId);

            message.MarkAsDeleted(null);
            messagesDbContext.Messages.Attach(message);
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}