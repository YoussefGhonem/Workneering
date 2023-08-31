using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Workneering.Base.Application.FluentValidation.Validators;
using Workneering.Identity.Domain.Entities;

namespace Workneering.Identity.Application.Commands.Identity.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly IPasswordHasher<User> _passwordHasher;
    private User? _user;

    public ChangePasswordCommandValidator(UserManager<User> userManager, IPasswordHasher<User> passwordHasher)
    {
        _userManager = userManager;
        _passwordHasher = passwordHasher;
        CascadeMode = CascadeMode.Stop;

        RuleFor(p => p.UserId)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .MustAsync(BeExitUser);


        RuleFor(c => c.CurrentPassword)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .Must(BeCorrectPassword).WithMessage("Old password is incorrect.");

        RuleFor(c => c.NewPassword)
            .SetValidator(new PasswordValidator())
            .Must(BeDifferentPassword).WithMessage("The new password shouldn't be equal to the old one.");

        RuleFor(c => c.ConfirmPassword)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .Must(IsMatch).WithMessage("Your confirm password doesn't match the new password.");
    }

    private async Task<bool> BeExitUser(Guid id, CancellationToken cancellationToken)
    {
        _user = await _userManager.FindByIdAsync(id.ToString());
        return _user is not null;
    }
    private bool BeCorrectPassword(string currentPassword)
    {
        if (_user is null) return false;
        return _passwordHasher.VerifyHashedPassword(_user, _user.PasswordHash, currentPassword) ==
               PasswordVerificationResult.Success;
    }
    private bool BeDifferentPassword(string newPassword)
    {
        return !(_passwordHasher.VerifyHashedPassword(_user!, _user!.PasswordHash, newPassword) == PasswordVerificationResult.Success);
    }
    private bool IsMatch(ChangePasswordCommand command, string confirmPassword)
    {
        return confirmPassword == command.NewPassword;
    }
}