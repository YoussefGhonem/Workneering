using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.ForgetPassword;

public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
{
    private readonly IdentityDatabaseContext _context;
    private Workneering.Identity.Domain.Entities.User? _user;

    public ForgetPasswordCommandValidator(IdentityDatabaseContext context)
    {
        CascadeMode = CascadeMode.Stop;
        _context = context;
        RuleFor(c => c.Email)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .EmailAddress().WithMessage("Invalid email")
            .MustAsync(BeExistUser).WithMessage("Email is not found");
    }

    private async Task<bool> BeExistUser(string email, CancellationToken cancellationToken)
    {
        _user = await _context.Users
            .Include(u => u.Claims)
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return _user is not null;
    }
}