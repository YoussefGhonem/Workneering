using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Queries.Project.GetProjects.Filters;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

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
            try
            {
                var query = await _context.Projects
                    .Include(x => x.Wishlist)
                    .Include(x => x.Categories)
                    .Include(x => x.SubCategories)
                    .Include(x => x.Skills)
                    .Where(x => x.ProjectStatus!.Value == Domain.Enums.ProjectStatusEnum.Posted)
                    .Where(x => request.IsFreelancer ? x.ProjectType == Domain.Enums.ProjectTypeEnum.Basic :
                                (x.ProjectType == Domain.Enums.ProjectTypeEnum.Basic &&
                                 x.ProjectType == Domain.Enums.ProjectTypeEnum.ByWorkneering))
                    .OrderByDescending(a => a.CreatedDate)
                    .AsQueryable()
                    .Filter(request, _dbQueryService);

                var dataQuery = await query.PaginateAsync(request.PageSize, request.PageNumber);

                var result = dataQuery.list.Adapt<List<ProjectListDto>>();

                if (request.IsFreelancer)
                {
                    foreach (var item in result.ToList())
                    {
                        item.IsSaved = query.Any(project => project.Wishlist
                                    .Any(Wishlist => Wishlist.FreelancerId == CurrentUser.Id && item.Id == project.Id));


                    }
                }
                return new PaginationResult<ProjectListDto>(result.ToList(), dataQuery.total);
            }
            catch (Exception ex)
            {

                throw;
            }





        }
    }
}
