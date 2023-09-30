namespace Workneering.Message.Application.Queries.Message.GetConversation
{
    public class GetConversationDto
    {
        public Guid? Id { get; set; }
        public Guid? SenderId { get; set; }
        public string? SenderName { get; set; }
        public string? SenderTitle { get; set; }
        public string? SenderPhotoUrl { get; set; }
        public Guid RecipientId { get; set; }
        public string? RecipientName { get; set; }
        public string? RecipientTitle { get; set; }
        public string? RecipientPhotoUrl { get; set; }
        public string? Content { get; set; }
        public bool? IsRead { get; set; }
        public DateTimeOffset? DateRead { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }

}
