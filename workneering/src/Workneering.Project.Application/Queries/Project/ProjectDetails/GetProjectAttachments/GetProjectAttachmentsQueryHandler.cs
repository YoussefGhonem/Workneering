using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectAttachments
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetProjectAttachmentsQuery, List<ProjectAttachmentsDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext dbContext, IDbQueryService dbQueryService, IStorageService storageService)
        {
            _context = dbContext;
            _dbQueryService = dbQueryService;
            _storageService = storageService;
        }
        public async Task<List<ProjectAttachmentsDto>> Handle(GetProjectAttachmentsQuery request, CancellationToken cancellationToken)
        {
            Mapper.Mapping(_storageService);
            var query = _context.Projects.Include(x => x.Attachments).FirstOrDefault(x => x.Id == request.ProjectId);
            var result = query.Attachments?.Adapt<List<ProjectAttachmentsDto>>();

            return result;
        }
    }
}
