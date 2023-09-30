using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Queries.Proposal.GetProposals.Filters;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

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

            var proposals = await _context.Projects.Where(x => x.ClientId == CurrentUser.Id)
                .Include(x => x.Proposals)
                .Include(x => x.Categories)
                .AsQueryable()
                .Filter(request, _dbQueryService)
                .PaginateAsync(request.PageSize, request.PageNumber);
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
