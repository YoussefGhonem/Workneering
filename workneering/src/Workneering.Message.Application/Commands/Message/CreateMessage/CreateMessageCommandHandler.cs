using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Message.Domain.Entities;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;

        public CreateMessageCommandHandler(IMediator mediator, MessagesDbContext identityDatabase)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Domain.Entities.Message(request.Content, request.RecipientId, CurrentUser.Id);
            await messagesDbContext.Messages.AddAsync(message, cancellationToken);
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}