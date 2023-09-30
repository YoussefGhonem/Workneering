using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProposals
{
    public class ClientProposalsListDto
    {
        public Guid Id { get; set; }
        public FreelancerInfoDto FreelancerDetails { get; set; } = new();
        public string? CoverLetter { get; set; }
        public Guid? FreelancerId { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public decimal? TotalBid { get; set; }
        public string? ProposalDuration { get; set; }
        public ProposalStatusEnum? ProposalStatus { get; set; }
    }
    public class FreelancerInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string CountryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
