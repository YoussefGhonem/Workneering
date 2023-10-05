using Workneering.Message.Domain.Entities;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRoomsForFreelancer
{
    public class RoomsForFreelancerDto
    {
        public Guid? Id { get; set; }
        public Guid? ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientTitle { get; set; }
        public string? ClientCountryName { get; set; }
        public string? ClientImageUrl { get; set; }
        public string? LastMessage { get; set; }
        public DateTimeOffset? LastMessageCreatedDate { get; set; }
    }
}
