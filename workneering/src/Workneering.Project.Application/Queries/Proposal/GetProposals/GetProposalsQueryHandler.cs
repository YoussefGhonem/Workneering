using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Application.Queries.Proposal.GetProposals.Filters;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals
{
    public class GetProposalsQueryHandler : IRequestHandler<GetProposalsQuery, PaginationResult<ProposalsDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetProposalsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<ProposalsDto>> Handle(GetProposalsQuery request, CancellationToken cancellationToken)
        {

            var proposals = _context.Projects
                .Include(x => x.Proposals)
                .AsQueryable()
                .Filter(request, _dbQueryService)
                .Paginate(request.PageSize, request.PageNumber);
            var result = proposals.Adapt<List<ProposalsDto>>();

            foreach (var item in result.ToList())
            {
                var userInfo = _dbQueryService.GetFreelancerInfoForProposals(item.FreelancerId);
                item.Freelancer.Id = userInfo.Id;
                item.Freelancer.Name = userInfo.Name;
                item.Freelancer.Title = userInfo.Title;
                item.Freelancer.CountryName = userInfo.CountryName;
            }

            return new PaginationResult<ProposalsDto>(result.ToList(), proposals.total);

        }
    }
}
