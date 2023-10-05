using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        private readonly ProjectsDbContext _context;

        public DeleteProjectCommandValidator(ProjectsDbContext context)
        {

            _context = context;

            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Must(BeExist).WithMessage("Project is not found.")
                .Must(BeAvailableToUpdate).WithMessage("the Project is not Posted, so you can't remove it.")

                .NotEmpty();
        }

        private bool BeExist(Guid id)
        {
            return _context.Projects.Any(x => x.Id == id);
        }
        private bool BeAvailableToUpdate(Guid id)
        {
            var projectStatus = _context.Projects.FirstOrDefault(x => x.Id == id)!.ProjectStatus;
            if (projectStatus == Domain.Enums.ProjectStatusEnum.Posted) return true;
            return false;
        }
    }
}