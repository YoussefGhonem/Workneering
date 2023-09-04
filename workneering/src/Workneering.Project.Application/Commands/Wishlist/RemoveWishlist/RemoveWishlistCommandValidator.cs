using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.Wishlist.RemoveWishlist
{
    public class RemoveWishlistCommandValidator : AbstractValidator<RemoveWishlistCommand>
    {
        private readonly ProjectsDbContext _context;

        public RemoveWishlistCommandValidator(ProjectsDbContext context)
        {
            _context = context;

            RuleFor(r => r.ProjectId)
                .Cascade(CascadeMode.Stop)
                .Must(BeExist).WithMessage("Project is not found.")
                .NotNull()
                .NotEmpty();
        }
        private bool BeExist(Guid? id)
        {
            return _context.Projects.Any(x => x.Id == id);

        }
    }
}