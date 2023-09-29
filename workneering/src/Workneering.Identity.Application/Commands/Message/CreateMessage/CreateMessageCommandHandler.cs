using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

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
            var recipient = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.RecipientId, cancellationToken: cancellationToken);
            var sender = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.SenderId, cancellationToken: cancellationToken);

            var message = await _identityDbContext.Messages
                .Include(x => x.Recipient)
                .Include(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id);

            message!.AddMessage(request.Content, sender, recipient);
            await _identityDbContext.Messages.AddAsync(message, cancellationToken);
            await _identityDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}