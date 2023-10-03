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
    public class GetProposalsQueryHandler : IRequestHandler<GetProposalsQuery, PaginationResult<ProjectProposalsDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetProposalsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<ProjectProposalsDto>> Handle(GetProposalsQuery request, CancellationToken cancellationToken)
        {
            Mapper.Mapping(_dbQueryService);
            var projects = await _context.Projects
           .Include(x => x.Proposals)
           .Filter(request, _dbQueryService)
           .Where(p => p.Proposals
               .Any(p => p.FreelancerId == CurrentUser.Id))
           .OrderByDescending(p => p.Proposals
               .Where(p => p.FreelancerId == CurrentUser.Id)
               .Max(p => p.CreatedDate))
           .PaginateAsync(request.PageSize, request.PageNumber, cancellationToken: cancellationToken);


            var result = projects.list.Adapt<List<ProjectProposalsDto>>();

            var proposals = projects.list.Select(x => x.Proposals);

            return new PaginationResult<ProjectProposalsDto>(result.ToList(), projects.total);

        }
    }
}
