using FluentValidation;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IdentityDatabaseContext _context;
        private readonly UserManager<Workneering.Identity.Domain.Entities.User> _userManager;
        private readonly IPasswordHasher<Workneering.Identity.Domain.Entities.User> _passwordHasher;
        private Workneering.Identity.Domain.Entities.User? _user;

        public LoginCommandValidator(IdentityDatabaseContext context,
            UserManager<Workneering.Identity.Domain.Entities.User> userManager,
            IPasswordHasher<Workneering.Identity.Domain.Entities.User> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            RuleFor(r => r.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MustAsync(BeExistUser).WithMessage("Email is not found")
                .Must(BeExistPassword).WithMessage("Please, reset your password first to be able to login")
                .MustAsync((command, email, cancellationToken) => BeCorrectPassword(command.Password, cancellationToken))
                .WithMessage("Password is not valid");


            RuleFor(p => p.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }

        private async Task<bool> BeExistUser(string email, CancellationToken cancellation)
        {
            _user = await _context.Users
                .Where(user => user.Email == email)
                .Include(user => user.UserRoles).ThenInclude(role => role.Role)
                .Include(user => user.Claims)
                .FirstOrDefaultAsync(cancellationToken: cancellation);
            return _user is not null;
        }

        private bool BeExistPassword(string password)
        {
            return _user!.PasswordHash is not null;
        }

        private async Task<bool> BeCorrectPassword(string password, CancellationToken cancellationToken)
        {
            var isValidPassword = _passwordHasher.VerifyHashedPassword(_user!, _user!.PasswordHash, password)
                                  == PasswordVerificationResult.Success;
            if (isValidPassword) return true;
            await _userManager.AccessFailedAsync(_user);

            return false;
        }

    }
}