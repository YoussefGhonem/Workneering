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
    }

    private async Task<bool> BeExitUser(Guid id, CancellationToken cancellationToken)
    {
        _user = await _userManager.FindByIdAsync(id.ToString());
        return _user is not null;
    }

}