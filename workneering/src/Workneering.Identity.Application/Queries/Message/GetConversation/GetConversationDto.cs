namespace Workneering.Identity.Application.Queries.Message.GetConversation
{
    public class GetConversationDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Email { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public bool? SenderDeleted { get; set; }
        public bool? RecipientDeleted { get; set; }
    }

}
