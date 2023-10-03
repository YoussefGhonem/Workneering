using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals.Filters;
public class ProposalsListFilters : BaseFilterDto
{
    public Guid? ProjectId { get; set; } // from rout
    public Guid? FreelancerId { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? Id { get; set; }
    public ProposalStatusEnum? Status { get; set; }
}

