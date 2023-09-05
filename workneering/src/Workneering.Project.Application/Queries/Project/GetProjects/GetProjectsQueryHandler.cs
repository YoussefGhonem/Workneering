using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Application.Queries.Project.GetProjects.Filters;

namespace Workneering.Project.Application.Queries.Project.GetProjects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, PaginationResult<ProjectListDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetProjectsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<ProjectListDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {

            var query = _context.Projects
                .Include(x => x.Wishlist)
                .Include(x => x.ProjectCategory)
                .Where(x => x.Wishlist.Any(x => x.FreelancerId == CurrentUser.Id))
                .OrderByDescending(a => a.CreatedDate)
                .AsQueryable()
                .Filter(request, _dbQueryService)
                .Paginate(request.PageSize, request.PageNumber);
            var result = query.Adapt<List<ProjectListDto>>();
            if (CurrentUser.Roles.Contains(Shared.Core.Identity.Enums.RolesEnum.Freelancer))
            {
                foreach (var item in result.ToList())
                {
                    item.IsSaved = query.list.Any(x => x.Wishlist.Any(x => x.FreelancerId == CurrentUser.Id));
                }
            }
            return new PaginationResult<ProjectListDto>(result.ToList(), query.total);

        }
    }
}
