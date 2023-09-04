using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.Wishlist.CreateWishlist
{
    public class CreateWishlistCommandValidator : AbstractValidator<CreateWishlistCommand>
    {
        private readonly ProjectsDbContext _context;

        public CreateWishlistCommandValidator(ProjectsDbContext context)
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