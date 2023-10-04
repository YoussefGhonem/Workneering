using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Models;

namespace Workneering.Message.Domain.Entities
{
    public record GlopalChatAttachments : BaseEntity
    {
        private FileDto _attachments = new();

        public GlopalChatAttachments()
        {
        }
        public FileDto Attachments { get => _attachments; set => _attachments = value; }
    }
}