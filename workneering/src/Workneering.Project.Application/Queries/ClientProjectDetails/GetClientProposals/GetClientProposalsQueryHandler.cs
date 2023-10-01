using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProposals
{
    public class GetClientProposalsQueryHandler : IRequestHandler<GetClientProposalsQuery, PaginationResult<ClientProposalsListDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetClientProposalsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<ClientProposalsListDto>> Handle(GetClientProposalsQuery request, CancellationToken cancellationToken)
        {

            var proposals = await _context.Projects.Where(x => x.Id == request.ProjectId)
                .Include(x => x.Proposals)
                .AsQueryable()
                .PaginateAsync(request.PageSize, request.PageNumber);

            var list = proposals.list.SelectMany(x => x.Proposals).ToList();
            var result = list.Adapt<List<ClientProposalsListDto>>();

            foreach (var item in result.ToList())
            {
                var userInfo = await _dbQueryService.GetFreelancerInfoForProposals(item.FreelancerId.Value, cancellationToken);
                var freelancerImage = await _dbQueryService.GetFreelancerImage(item.FreelancerId.Value);
                item.FreelancerDetails.Id = userInfo.Id;
                item.FreelancerDetails.Name = userInfo.Name;
                item.FreelancerDetails.Title = userInfo.Title;
                item.FreelancerDetails.CountryName = userInfo.CountryName;
                item.FreelancerDetails.ImageUrl = freelancerImage.Url;
            }

            return new PaginationResult<ClientProposalsListDto>(result.ToList(), proposals.total);
        }
    }
}