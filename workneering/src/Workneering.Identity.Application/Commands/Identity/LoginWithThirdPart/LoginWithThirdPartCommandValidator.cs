using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Application.Commands.Identity.LoginWithThirdPart;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.Login
{
    public class LoginWithThirdPartCommandValidator : AbstractValidator<LoginWithThirdPartCommand>
    {
        private readonly IdentityDatabaseContext _context;
        private readonly UserManager<Workneering.Identity.Domain.Entities.User> _userManager;
        private readonly IPasswordHasher<Workneering.Identity.Domain.Entities.User> _passwordHasher;
        private Workneering.Identity.Domain.Entities.User? _user;

        public LoginWithThirdPartCommandValidator(IdentityDatabaseContext context,
            UserManager<Workneering.Identity.Domain.Entities.User> userManager,
            IPasswordHasher<Workneering.Identity.Domain.Entities.User> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            RuleFor(r => r.provider).NotEmpty().NotNull();
            RuleFor(r => r.userId);
                //.MustAsync(BeExistUser).WithMessage("Email is not found")
            RuleFor(r => r.accessToken).NotNull().NotEmpty();
        }

        private async Task<bool> BeExistUser(string userName, CancellationToken cancellation)
        {
            _user = await _context.Users
                .Where(user => user.UserName == userName)
                .Include(user => user.UserRoles).ThenInclude(role => role.Role)
                .Include(user => user.Claims)
                .FirstOrDefaultAsync(cancellationToken: cancellation);
            return _user is not null;
        }

    }
}