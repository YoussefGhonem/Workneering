using Ardalis.GuardClauses;
using Workneering.Base.Domain.Common;

namespace Workneering.Identity.Domain.Entities
{
    public record Message : BaseEntity
    {
        private string? _content;
        private bool? _isRead;
        private DateTime? _dateRead;
        private bool? _senderDeleted;
        private bool? _recipientDeleted;
        private User _sender;
        private User _recipient;



        public string? Content { get => _content; set => _content = value; }
        public bool? IsRead { get => _isRead; set => _isRead = value; }
        public DateTime? DateRead { get => _dateRead; set => _dateRead = value; }
        public bool? SenderDeleted { get => _senderDeleted; set => _senderDeleted = value; }
        public bool? RecipientDeleted { get => _recipientDeleted; set => _recipientDeleted = value; }
        public User Sender => _sender;
        public User Recipient => _recipient;
        public Message(string content)
        {
            _content = Guard.Against.NullOrWhiteSpace(content, nameof(content));

        }
        public Message()
        {

        }
    }
}
