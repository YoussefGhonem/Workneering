using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals
{
    public class ProjectProposalsDto
    {
        public Guid Id { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectStatus { get; set; }
        public List<ProposalListDto> Proposals { get; set; } = new();
        public ClientInfo? Client { get; set; } = new();
    }
    public class ProposalListDto
    {
        public Guid Id { get; set; }
        public Guid FreelancerId { get; set; }
        public string? CoverLetter { get; set; }
        public decimal? TotalBid { get; set; }
        public ProposalDurationEnum? ProposalDuration { get; set; }
        public string? ProposalStatus { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
    public class ClientInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string CountryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
