using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.RegisterWiththirdPart
{
    public class RegisterWiththirdPartValidator : AbstractValidator<RegisterWiththirdPartCommand>
    {
        private readonly IdentityDatabaseContext _context;
        private readonly UserManager<Workneering.Identity.Domain.Entities.User> _userManager;
        private Workneering.Identity.Domain.Entities.User? _user;

        public RegisterWiththirdPartValidator(IdentityDatabaseContext context,
            UserManager<Workneering.Identity.Domain.Entities.User> userManager)
        {
            _context = context;
            _userManager = userManager;
            RuleFor(r => r.provider).NotEmpty().NotNull();
            RuleFor(r => r.userId).NotNull().NotEmpty()
                .MustAsync(BeUnique)
                .WithMessage("This {PropertyValue} already exists");
            RuleFor(r=>r.accessToken).NotEmpty().NotNull();
            //RuleFor(r=>r.name).NotEmpty().NotNull();
            
        }

        private async Task<bool> BeUnique(string userId, CancellationToken cancellationToken)
        {
            var val = await _userManager.FindByNameAsync(userId);
            if (val != null)
            {
                return false;
            }
            return true;
        }
    }
}