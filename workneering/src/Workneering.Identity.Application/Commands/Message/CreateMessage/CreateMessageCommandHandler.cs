using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly IdentityDatabaseContext _identityDbContext;
        private readonly IMediator _mediator;

        public CreateMessageCommandHandler(IMediator mediator, IdentityDatabaseContext identityDatabase)
        {
            _identityDbContext = identityDatabase;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var sender = await _identityDbContext.Users
                .Include(x => x.MessagesReceived)
                .Include(x => x.MessagesSent)
                .FirstOrDefaultAsync(x => x.Id == request.SenderId);

            var recipient = await _identityDbContext.Users
                .Include(x => x.MessagesReceived)
                .Include(x => x.MessagesSent)
                .FirstOrDefaultAsync(x => x.Id == request.RecipientId);

            sender!.AddMessagesSent(request.Content);
            recipient!.AddMessagesReceived(request.Content);
            return Unit.Value;
        }
    }
}