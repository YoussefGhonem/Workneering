using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Message.Application.Queries.Notifications.GeNotifications
{
    public class GeNotificationsQuery : IRequest<PaginationResult<MessageNotificationsDto>>
    {
        public int Hand { get; set; }
        public int Next { get; set; }
    }
}
