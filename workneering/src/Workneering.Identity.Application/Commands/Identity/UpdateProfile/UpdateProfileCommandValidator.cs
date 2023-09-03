using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Workneering.Base.Application.FluentValidation.Validators;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Commands.Identity.UpdateProfile;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    private readonly UserManager<Domain.Entities.User> _userManager;
    private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
    private Domain.Entities.User? _user;

    public UpdateProfileCommandValidator(UserManager<Domain.Entities.User> userManager, IPasswordHasher<Domain.Entities.User> passwordHasher)
    {
        _userManager = userManager;
        _passwordHasher = passwordHasher;
        CascadeMode = CascadeMode.Stop;

        RuleFor(p => CurrentUser.Id.Value)
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
    private bool IsMatch(UpdateProfileCommand command, string confirmPassword)
    {
        return confirmPassword == command.NewPassword;
    }
}