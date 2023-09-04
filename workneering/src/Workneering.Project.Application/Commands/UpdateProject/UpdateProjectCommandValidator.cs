using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        private readonly ProjectsDbContext _context;

        public UpdateProjectCommandValidator(ProjectsDbContext context)
        {

            _context = context;

            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Must(BeAvailableToUpdate).WithMessage("the Project is not Drafted, so You can't update on it.")
                .Must(BeExist).WithMessage("Project is not found.")
                .NotEmpty();
        }

        private bool BeExist(Guid id)
        {
            return _context.Projects.Any(x => x.Id == id);
        }

        private bool BeAvailableToUpdate(Guid id)
        {
            var projectStatus = _context.Projects.FirstOrDefault(x => x.Id == id)!.ProjectStatus;
            if (projectStatus != Domain.Enums.ProjectStatusEnum.Draft) return false;
            return true;
        }
    }
}