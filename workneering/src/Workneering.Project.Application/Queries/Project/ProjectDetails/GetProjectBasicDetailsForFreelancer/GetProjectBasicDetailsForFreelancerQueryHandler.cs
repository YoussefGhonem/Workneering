using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetails
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
            var query = _context.Projects.FirstOrDefault(x => x.Id == request.ProjectId);
            var userservice = _dbQueryService.GetFreelancerInfoForProposals(query.ClientId!.Value);
            var result = query?.Adapt<ProjectBasicDetailsForFreelancerDto>();


            return result;
        }
    }
}
