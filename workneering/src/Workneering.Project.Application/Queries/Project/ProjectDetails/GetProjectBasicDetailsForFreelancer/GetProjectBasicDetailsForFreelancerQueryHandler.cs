using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Identity.Enums;

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
            var result = query?.Adapt<ProjectBasicDetailsForFreelancerDto>();

            var userservice = _dbQueryService.GetClientInfoForProjectDetails(query.ClientId!.Value);
            result.ClientInfo.Name = userservice.Name;
            result.ClientInfo.Title = userservice.Title;
            result.ClientInfo.CountryName = userservice.CountryName;
            result.ClientInfo.FoundedIn = userservice.FoundedIn;
            result.ClientInfo.TitleOverview = userservice.TitleOverview;
            result.ClientInfo.CompanySize = userservice.CompanySize;

            var industryName = _dbQueryService.GetIndustryName(query.ClientId!.Value);
            result.ClientInfo.IndustryName = industryName;
            var clientType = _dbQueryService.GetUserRole(query.ClientId!.Value);
            result.ClientType = clientType;
            result.ProjectBudgetEnum = query.ProjectBudget;


            result.IsSaved = query.Wishlist.Any(x => x.FreelancerId == CurrentUser.Id);
            var numofProjects = _context.Projects.Select(x => new { x.ProjectStatus, x.ClientId }).
                                                 Where(x => x.ClientId == query.ClientId &&
                                                 x.ProjectStatus == Domain.Enums.ProjectStatusEnum.Posted).Count();
            result.ClientInfo.NumOfProjects = numofProjects;
            if (result.ClientType == RolesEnum.Company.ToString())
                result.ClientInfo.IsCompany = true;
            return result;
        }
    }
}
