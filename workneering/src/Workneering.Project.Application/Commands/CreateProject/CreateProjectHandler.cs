using MediatR;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Project.Application.Commands.CreateProject.Helpers;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.CreateProject
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService, IStorageService storageService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
            _storageService = storageService;
        }
        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            var categories = _dbQueryService.GetCategoriesForProject(request.CategoriesIds);
            var Supcategoris = _dbQueryService.GetSupCateforiesForProject(request.SubCategoriesIds);
            var skills = _dbQueryService.GetSkillsForProject(request.SkillsIds);

            var command = await request.CreatProject(categories, Supcategoris, skills, _storageService, cancellationToken);

            await _context.Projects.AddAsync(command, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
