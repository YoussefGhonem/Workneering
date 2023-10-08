using Workneering.Base.Domain.Common;

namespace Workneering.Message.Domain.Entities;
public record MessegeNotifications : BaseEntity
{
    private string? _title;
    private string? _content;
    private Guid? _projectId;
    private Guid? _roomId;
    private Guid? _recipientId;
    private Guid? _senderId;
    private bool _isRead = false;
    private DateTimeOffset? _dateRead;

    public MessegeNotifications(Guid recipientId, string? title, string? content, Guid? projectId, Guid? roomId, Guid? senderId = null)
    {
        _title = title;
        _content = content;
        _projectId = projectId;
        _roomId = roomId;
        _recipientId = recipientId;
        _senderId = senderId;
    }
    public MessegeNotifications()
    {

    }
    public Guid? ProjectId { get => _projectId; set => _projectId = value; }
    public Guid? RoomId { get => _roomId; set => _roomId = value; }
    public Guid? RecipientId { get => _recipientId; set => _recipientId = value; }
    public Guid? SenderId { get => _senderId; set => _senderId = value; }
    public string? Title { get => _title; set => _title = value; }
    public string? Content { get => _content; set => _content = value; }
    public bool IsRead { get => _isRead; set => _isRead = value; }
    public DateTimeOffset? DateRead { get => _dateRead; set => _dateRead = value; }

    public void MarkMessageAsRead()
    {
        _isRead = true;
        _dateRead = DateTimeOffset.Now;
    }

}
