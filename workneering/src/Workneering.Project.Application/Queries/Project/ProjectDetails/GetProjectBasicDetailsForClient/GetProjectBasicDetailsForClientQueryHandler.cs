using Mapster;
using MediatR;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForClient
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetProjectBasicDetailsForClientQuery, GetProjectBasicDetailsForClientDto>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext dbContext, IDbQueryService dbQueryService)
        {
            _context = dbContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<GetProjectBasicDetailsForClientDto> Handle(GetProjectBasicDetailsForClientQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Projects.FirstOrDefault(x => x.Id == request.ProjectId);
            var userservice = _dbQueryService.GetClientInfoForProjectDetails(query.ClientId!.Value);
            var result = query?.Adapt<GetProjectBasicDetailsForClientDto>();

            return result;
        }
    }
}
