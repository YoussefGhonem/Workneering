using System.Linq.Dynamic.Core;
using Workneering.Project.Application.Services.DbQueryService;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals.Filters
{
    public static class ApplyFilterExtension
    {
        public static IQueryable<Domain.Entities.Project> Filter(
            this IQueryable<Domain.Entities.Project> query, GetProposalsQuery filters, IDbQueryService _dbQueryService)
        {
            // Filters  

            if (filters.Status is not null)
            {
                query = query.Where(x => x.Proposals.Any(x => x.ProposalStatus == filters.Status));
            }

            return query;

        }

    }
}
