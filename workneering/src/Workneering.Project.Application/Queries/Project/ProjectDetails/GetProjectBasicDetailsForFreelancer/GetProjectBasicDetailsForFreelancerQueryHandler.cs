using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForFreelancer
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetProjectBasicDetailsForFreelancerQuery, ProjectBasicDetailsForFreelancerDto>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext dbContext, IDbQueryService dbQueryService)
        {
            _context = dbContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<ProjectBasicDetailsForFreelancerDto> Handle(GetProjectBasicDetailsForFreelancerQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Projects
                                .Include(x => x.Categories)
                                .Include(x => x.SubCategories)
                                .Include(x => x.Skills)
                                .Include(x => x.Wishlist)
                                .FirstOrDefault(x => x.Id == request.ProjectId);

            var userservice = _dbQueryService.GetClientInfoForProjectDetails(query.ClientId!.Value);
            var result = query?.Adapt<ProjectBasicDetailsForFreelancerDto>();
            result.IsSaved = query.Wishlist.Any(x => x.FreelancerId == CurrentUser.Id);
            result.ClientInfo.Name = userservice.Name;
            result.ClientInfo.Title = userservice.Title;
            result.ClientInfo.CountryName = userservice.CountryName;
            result.ClientType = userservice.CountryName;
            result.ProjectBudgetEnum = query.ProjectBudget;

            return result;
        }
    }
}
