using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects.Filters;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Domain.Entities;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects
{
    public class GetClientProjectsQueryHandler : IRequestHandler<GetClientProjectsQuery, PaginationResult<ClientProjectsDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetClientProjectsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<ClientProjectsDto>> Handle(GetClientProjectsQuery request, CancellationToken cancellationToken)
        {

            var projects = await _context.Projects.Where(x => x.ClientId == CurrentUser.Id)
                .Include(x => x.Proposals)
                .AsQueryable()
                .Filter(request)
                .PaginateAsync(request.PageSize, request.PageNumber);

            var result = projects.list.Adapt<List<ClientProjectsDto>>();

            foreach (var projectDto in result)
            {
                // Count the number of proposals for the project
                projectDto.NumberOfProposals = projects.list.SelectMany(x => x.Proposals).Count();

                if (projectDto.AssginedFreelancerId != null)
                {
                    var userInfo = await _dbQueryService.GetFreelancerInfo(projectDto.AssginedFreelancerId.Value);
                    projectDto.AssginedFreelancer = new AssginedFreelancerDto
                    {
                        FreelancerId = projectDto.AssginedFreelancerId.Value,
                        CountryName = userInfo.CountryName,
                        Name = userInfo.Name,
                        Title = userInfo.Title
                    };
                }
            }

            return new PaginationResult<ClientProjectsDto>(result.ToList(), projects.total);

        }
    }
}
