using Ardalis.GuardClauses;
using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Domain.Entities
{
    public record GlopalChat : BaseEntity
    {
        private string _content;
        private Guid _createdUserId;
        private Guid _roomId;
        private bool _isRead = false;
        private DateTime? _dateRead;
        private List<GlopalChatAttachments>? _glopalChatAttachments = new();

        public string Content { get => _content; set => _content = value; }
        public bool IsRead { get => _isRead; set => _isRead = value; }
        public Guid CreatedUserId { get => _createdUserId; set => _createdUserId = value; }
        public Guid RoomId { get => _roomId; set => _roomId = value; }
        public DateTime? DateRead { get => _dateRead; set => _dateRead = value; }
        public List<GlopalChatAttachments>? GlopalChatAttachments => _glopalChatAttachments;

        public GlopalChat(string content, Guid roomId, List<GlopalChatAttachments>? glopalChatAttachments)
        {
            _content = Guard.Against.NullOrWhiteSpace(content, nameof(content));
            _createdUserId = CurrentUser.Id.Value;
            _glopalChatAttachments = glopalChatAttachments;
            _roomId = roomId;
        }
        public GlopalChat()
        {

        }
    }
}
