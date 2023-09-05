using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals
{
    public class ProposalsDto
    {
        public Guid FreelancerId { get; set; }
        public Guid Id { get; set; }
        public string? CoverLetter { get; set; }
        public FreelancerInfoDto? Freelancer { get; set; } = new();
        public decimal? HourlyRate { get; set; }
        public decimal? TotalBid { get; set; }
        public ProposalDurationEnum? ProposalDuration { get; set; }
        public ProposalStatusEnum? ProposalStatus { get; set; }
    }
    public class FreelancerInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string CountryName { get; set; }
    }
}
