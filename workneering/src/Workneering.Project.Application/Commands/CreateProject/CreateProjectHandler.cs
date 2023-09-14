using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Application.Commands.CreateProject.Helpers;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.CreateProject
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly ProjectsDbContext _context;
		private readonly IDbQueryService _dbQueryService;

		public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
		{
			_context = context;
			_dbQueryService = dbQueryService;
		}
		public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

			var categories = _dbQueryService.GetCategoriesForProject(request.categoriesIds);
			var Supcategoris = _dbQueryService.GetSupCateforiesForProject(request.subCategoriesIds);
			var skills = _dbQueryService.GetSkillsForProject(request.skillsIds);

			var command = request.CreatProject(categories, Supcategoris, skills);

            await _context.Projects.AddAsync(command, cancellationToken);
            _context?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
