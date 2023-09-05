using System.Linq.Dynamic.Core;
using Workneering.Project.Application.Services.DbQueryService;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals.Filters
{
    public static class ApplyFilterExtension
    {
        public static IQueryable<Domain.Entities.Proposal> Filter(
            this IQueryable<Domain.Entities.Project> query, GetProposalsQuery filters, IDbQueryService _dbQueryService)
        {
            // Filters  
            var proposal = query.SelectMany(x => x.Proposals);

            if (filters.ProjectId is not null)
            {
                proposal = query.Where(x => x.Id == filters.ProjectId).SelectMany(x => x.Proposals);
            }
            if (filters.ClientId is not null)
            {
                proposal = query.Where(x => x.ClientId == filters.ClientId).SelectMany(x => x.Proposals);
            }
            if (filters.FreelancerId is not null)
            {
                proposal = query.Where(x => x.Proposals.Any(x => x.FreelancerId == filters.FreelancerId)).SelectMany(x => x.Proposals);
            }
            if (filters.ProposalStatus is not null)
            {
                proposal = query.Where(x => x.Proposals.Any(x => x.ProposalStatus == filters.ProposalStatus)).SelectMany(x => x.Proposals);
            }


            return proposal;

        }

    }
}
