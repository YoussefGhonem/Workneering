using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectActivity
{
    public class GetProjectActivitiesQueryHandler : IRequestHandler<GetProjectActivitiesQuery, PaginationResult<ProjectActivitiesDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetProjectActivitiesQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<ProjectActivitiesDto>> Handle(GetProjectActivitiesQuery request, CancellationToken cancellationToken)
        {

            var activities = await _context.Projects.Include(x => x.Activities).Where(x => x.Id == request.ProjectId)
                .AsQueryable()
                .PaginateAsync(request.PageSize, request.PageNumber);

            var list = activities.list.SelectMany(x => x.Activities).ToList().OrderByDescending(x => x.CreatedDate);
            var result = list.Adapt<List<ProjectActivitiesDto>>();


            return new PaginationResult<ProjectActivitiesDto>(result.ToList(), activities.total);
        }
    }
}