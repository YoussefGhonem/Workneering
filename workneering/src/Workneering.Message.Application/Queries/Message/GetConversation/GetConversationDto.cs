using Workneering.Message.Domain.Entities;

namespace Workneering.Message.Application.Queries.Message.GetConversation
{
    public class GetConversationDto
    {
        public Guid? Id { get; set; }
        public Guid? CreatedUserId { get; set; }
        public string? CreatedUserName { get; set; }
        public string? CreatedUserTitle { get; set; }
        public string? CreatedUserCountryName { get; set; }
        public string? CreatedUserPhotoUrl { get; set; }
        public string? Content { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public List<MessageAttachmentsDto>? MessageAttachments { get; set; }

    }

    public class MessageAttachmentsDto
    {
        public string? Key { get; set; }
        public string? FileName { get; set; }
        public string? Extension { get; set; }
        public string? Url { get; set; }
        public long? FileSize { get; set; }

    }

}
