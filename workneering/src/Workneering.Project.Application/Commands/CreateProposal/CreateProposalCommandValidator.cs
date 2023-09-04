using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.CreateProposal
{
    public class CreateProposalCommandValidator : AbstractValidator<CreateProposalCommand>
    {
        private readonly ProjectsDbContext _context;


        public CreateProposalCommandValidator(ProjectsDbContext context)
        {
            _context = context;

            RuleFor(r => r.ProjectId)
                .Cascade(CascadeMode.Stop)
                .Must(BeExist).WithMessage("Project is not found.")
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.CoverLetter)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.ProposalDuration)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

        private bool BeExist(Guid? id)
        {
            return _context.Projects.Any(x => x.Id == id);

        }


    }
}