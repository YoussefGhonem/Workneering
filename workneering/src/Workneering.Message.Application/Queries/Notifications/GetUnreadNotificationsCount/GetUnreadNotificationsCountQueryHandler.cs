using MediatR;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.Notifications.GetUnreadNotificationsCount
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetUnreadNotificationsCountQuery, UnreadNotificationsCountDto>
    {
        private readonly MessagesDbContext _identityDatabase;

        public GetFreelancerEducationDetailsQueryHandler(MessagesDbContext userDatabaseContext)
        {
            _identityDatabase = userDatabaseContext;
        }
        public async Task<UnreadNotificationsCountDto> Handle(GetUnreadNotificationsCountQuery request, CancellationToken cancellationToken)
        {

            var counts = _identityDatabase.Notifications
                .Where(x => x.RecipientId == CurrentUser.Id && x.IsRead == false).Count();


            return new UnreadNotificationsCountDto() { UnreadCount = counts };
        }
    }
}
