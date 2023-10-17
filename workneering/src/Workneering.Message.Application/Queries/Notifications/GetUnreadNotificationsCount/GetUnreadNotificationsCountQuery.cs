using MediatR;

namespace Workneering.Message.Application.Queries.Notifications.GetUnreadNotificationsCount
{
    public class GetUnreadNotificationsCountQuery : IRequest<UnreadNotificationsCountDto>
    {
    }
}
