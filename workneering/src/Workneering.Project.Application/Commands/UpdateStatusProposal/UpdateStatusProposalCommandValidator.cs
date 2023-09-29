using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.UpdateStatusProposal
{
    public class UpdateStatusProposalCommandValidator : AbstractValidator<UpdateStatusProposalCommand>
    {
        private readonly ProjectsDbContext _context;


        public UpdateStatusProposalCommandValidator(ProjectsDbContext context)
        {
            _context = context;

            RuleFor(r => r.ProjectId)
                .Cascade(CascadeMode.Stop)
                .Must(BeExist).WithMessage("Project is not found.")
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Status)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();


        }

        private bool BeExist(Guid id)
        {
            return _context.Projects.Any(x => x.Id == id);

        }
    }
}