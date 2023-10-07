using MediatR;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.GlopalChat.GetCountRoomsUnread
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetCountRoomsUnreadQuery, CountRoomsUnreadDto>
    {
        private readonly MessagesDbContext _identityDatabase;

        public GetFreelancerEducationDetailsQueryHandler(MessagesDbContext userDatabaseContext)
        {
            _identityDatabase = userDatabaseContext;
        }
        public async Task<CountRoomsUnreadDto> Handle(GetCountRoomsUnreadQuery request, CancellationToken cancellationToken)
        {

            var isFreelancer = CurrentUser.Roles.Contains(Shared.Core.Identity.Enums.RolesEnum.Freelancer);

            var roomsIds = _identityDatabase.Rooms
                .Where(x => (isFreelancer ? x.FreelancerId : x.ClientId) == CurrentUser.Id).Select(x => x.Id);

            var messages = _identityDatabase.GlopalChat
                .Where(m => m.IsRead == false && m.CreatedUserId != CurrentUser.Id && roomsIds.Contains(m.RoomId));
            var count = messages.Select(x => x.RoomId).Distinct().Count();

            return new CountRoomsUnreadDto() { UnreadCount = count };
        }
    }
}
