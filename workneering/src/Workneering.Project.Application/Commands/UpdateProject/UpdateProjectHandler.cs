using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Application.Commands.CreateProject.Helpers;
using Workneering.Project.Application.Commands.UpdateProject.Helpers;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.UpdateProject
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly ProjectsDbContext _context;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Projects
                .Include(x => x.Skills)
                .Include(x => x.SubCategories)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == request.Id);

            var command = request.UpdateProject(query);

            _context.Projects.Attach(command);
            _context?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
