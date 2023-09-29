using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.RemoveProjectAttachment;
public class RemoveProjectAttachmentValidator : AbstractValidator<RemoveProjectAttachmentCommand>
{
    private readonly ProjectsDbContext _context;


    public RemoveProjectAttachmentValidator(ProjectsDbContext context)
    {
        _context = context;

        RuleFor(r => r.ProjectId)
            .Cascade(CascadeMode.Stop)
            .Must(BeExist).WithMessage("Project is not found.")
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Key)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

    }

    private bool BeExist(Guid guid)
    {
        return _context.Projects.Any(x => x.Id == guid);

    }
}
