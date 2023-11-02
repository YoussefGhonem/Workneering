using Workneering.Message.Domain.Entities;

namespace Workneering.Message.Application.Queries.Notifications.GeNotifications
{
    public class MessageNotificationsDto
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? RecipientId { get; set; }
        public Guid? SenderId { get; set; }
        public string? SenderImage { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public bool IsRead { get; set; }
    }
}
