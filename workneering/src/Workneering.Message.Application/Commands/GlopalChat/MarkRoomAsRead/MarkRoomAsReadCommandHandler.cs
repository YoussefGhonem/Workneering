using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Commands.GlopalChat.MarkRoomAsRead
{
    public class MarkRoomAsReadCommandHandler : IRequestHandler<MarkRoomAsReadCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;

        public MarkRoomAsReadCommandHandler(IMediator mediator, MessagesDbContext identityDatabase)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(MarkRoomAsReadCommand request, CancellationToken cancellationToken)
        {
            var messages = messagesDbContext.GlopalChat
                .Where(x => x.RoomId == request.RoomId && x.CreatedUserId != CurrentUser.Id && request.Ids.Contains(x.Id)).ToList();

            foreach (var item in messages)
            {
                item.MarkMessageAsRead();
            }
            messagesDbContext.GlopalChat.AttachRange(messages);
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}