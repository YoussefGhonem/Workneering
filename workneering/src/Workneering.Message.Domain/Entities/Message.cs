﻿using Ardalis.GuardClauses;
using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Domain.Entities
{
    public record Message : BaseEntity
    {
        private string _content;
        private Guid _createdUserId;
        private Guid _projectId;
        private bool _isRead = false;
        private DateTime? _dateRead;
        private List<MessageAttachments>? _messageAttachments = new();

        public string Content { get => _content; set => _content = value; }
        public bool IsRead { get => _isRead; set => _isRead = value; }
        public Guid CreatedUserId { get => _createdUserId; set => _createdUserId = value; }
        public Guid ProjectId { get => _projectId; set => _projectId = value; }
        public DateTime? DateRead { get => _dateRead; set => _dateRead = value; }
        public List<MessageAttachments>? MessageAttachments => _messageAttachments;

        public Message(string content, Guid projectId, List<MessageAttachments>? messageAttachments)
        {
            _content = Guard.Against.NullOrWhiteSpace(content, nameof(content));
            _createdUserId = CurrentUser.Id.Value;
            _messageAttachments = messageAttachments;
            _projectId = projectId;
        }
        public Message()
        {

        }
    }
}
