using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

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

            var proposals = _context.Projects.Where(x => x.Id == request.ProjectId)
                .Include(x => x.Proposals)
                .AsQueryable();

            var paginateAsync = await proposals.SelectMany(x => x.Proposals).PaginateAsync(request.PageSize, request.PageNumber);
            var result = paginateAsync.list.Adapt<List<ClientProposalsListDto>>();

            foreach (var item in result.ToList())
            {
                var userInfo = await _dbQueryService.GetFreelancerInfoForProposals(item.FreelancerId.Value, cancellationToken);
                var freelancerImage = await _dbQueryService.GetFreelancerImage(item.FreelancerId.Value);
                item.FreelancerDetails.Id = userInfo.Id;
                item.FreelancerDetails.Name = userInfo.Name;
                item.FreelancerDetails.Title = userInfo.Title;
                item.FreelancerDetails.CountryName = userInfo.CountryName;
                item.FreelancerDetails.ImageUrl = freelancerImage.Url;

                item.RoomId = await _dbQueryService.GetRoomId(CurrentUser.Id.Value, userInfo.Id);
            }

            return new PaginationResult<ClientProposalsListDto>(result.ToList(), paginateAsync.total);
        }
    }
}