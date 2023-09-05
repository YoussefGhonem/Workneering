using MediatR;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Queries.Proposal.GetProposals.Filters;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals
{
    public class GetProposalsQuery : ProposalsListFilters, IRequest<PaginationResult<ProposalsDto>>
    {

    }
}
