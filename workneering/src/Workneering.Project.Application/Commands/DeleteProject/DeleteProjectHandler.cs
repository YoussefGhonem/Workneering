using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Application.Commands.UpdateProject.Helpers;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.DeleteProject
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly ProjectsDbContext _context;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Projects
                .Include(x => x.Skills)
                .Include(x => x.SubCategories)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == request.Id);

            query.MarkAsDeleted(null);
            _context.Projects.Attach(query);
            _context?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
