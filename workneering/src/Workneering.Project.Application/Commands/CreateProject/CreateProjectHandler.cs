using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Application.Commands.CreateProject.Helpers;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.CreateProject
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly ProjectsDbContext _context;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            var command = request.CreatProject();

            await _context.Projects.AddAsync(command, cancellationToken);
            _context?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
