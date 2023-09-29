using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.RemoveProjectAttachment
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<RemoveProjectAttachmentCommand, Unit>
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
        public async Task<Unit> Handle(RemoveProjectAttachmentCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Projects.Include(x => x.Attachments).FirstOrDefault(x => x.Id == request.ProjectId);
            query.RemoveAttachment(request.Key);
            _context.Projects.Attach(query);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
