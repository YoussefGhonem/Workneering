using Ardalis.GuardClauses;
using Workneering.Base.Domain.Common;

namespace Workneering.Message.Domain.Entities
{
    public record Message : BaseEntity
    {
        private string? _content;
        private bool? _isRead;
        private DateTime? _dateRead;
        private bool? _senderDeleted;
        private bool? _recipientDeleted;
        private Guid? _senderId;
        private Guid? _recipientId;


        public string? Content { get => _content; set => _content = value; }
        public bool? IsRead { get => _isRead; set => _isRead = value; }
        public DateTime? DateRead { get => _dateRead; set => _dateRead = value; }
        public bool? SenderDeleted { get => _senderDeleted; set => _senderDeleted = value; }
        public bool? RecipientDeleted { get => _recipientDeleted; set => _recipientDeleted = value; }
        public Guid? SenderId { get => _senderId; set => _senderId = value; }
        public Guid? RecipientId { get => _recipientId; set => _recipientId = value; }

        public Message(string content, Guid? recipientId, Guid? senderId)
        {
            _content = Guard.Against.NullOrWhiteSpace(content, nameof(content));
            _senderId = senderId;
            _recipientId = recipientId;
        }
        public Message()
        {

        }

        public void MarkMessageAsRead()
        {
            IsRead = true;
        }
    }
}
