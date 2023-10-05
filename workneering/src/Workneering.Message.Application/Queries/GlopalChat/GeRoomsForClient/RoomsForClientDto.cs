namespace Workneering.Message.Application.Queries.GlopalChat.GeRoomsForClient
{
    public class RoomsForClientDto
    {
        public Guid? Id { get; set; }
        public Guid? FreelancerId { get; set; }
        public string? FreelancerName { get; set; }
        public string? FreelancerTitle { get; set; }
        public string? FreelancerCountryName { get; set; }
        public string? FreelancerImageUrl { get; set; }
        public string? LastMessage { get; set; }
        public DateTimeOffset? LastMessageCreatedDate { get; set; }
    }
}
