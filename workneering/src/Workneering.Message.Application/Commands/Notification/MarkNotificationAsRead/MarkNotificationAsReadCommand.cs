using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Message.Application.Commands.Notification.MarkNotificationAsRead
{
    public class MarkNotificationAsReadCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}