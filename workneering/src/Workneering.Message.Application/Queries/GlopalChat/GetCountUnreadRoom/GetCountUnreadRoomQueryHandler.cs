using MediatR;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.GlopalChat.GetCountUnreadRoom
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetCountUnreadRoomQuery, CountUnreadRoomDto>
    {
        private readonly MessagesDbContext _identityDatabase;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(MessagesDbContext userDatabaseContext, IStorageService storageService)
        {
            _identityDatabase = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<CountUnreadRoomDto> Handle(GetCountUnreadRoomQuery request, CancellationToken cancellationToken)
        {
            var userId = CurrentUser.Id;

            var messages = _identityDatabase.GlopalChat
                .Where(m => m.IsRead == false && m.RoomId == request.RoomId
                && m.CreatedUserId != CurrentUser.Id);
            var count = messages.Count();

            return new CountUnreadRoomDto() { UnreadCount = count };
        }
    }
}
