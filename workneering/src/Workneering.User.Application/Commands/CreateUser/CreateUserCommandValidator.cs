using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;
using Workneering.Base.Application.FluentValidation.Validators;
using Workneering.Identity.Domain.Entities;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.User.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly UserManager<User> _userManager;

        public CreateUserCommandValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.LastName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(b => b.Email)
                .SetValidator(new EmailValidator())
                .MustAsync(BeUnique).WithMessage("This {PropertyValue} already exists");

            RuleFor(b => b.Password)
                .SetValidator(new PasswordValidator());


            RuleFor(u => u.Role)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .IsInEnum().WithMessage("Invalid roll")
                .Must(BeValidRole).WithMessage("Registration not allowed for {PropertyValue} role");

        }

        private bool BeValidRole(RolesEnum role)
        {
            return role is RolesEnum.Client or RolesEnum.Company or RolesEnum.Freelancer;
        }

        private async Task<bool> BeUnique(string email, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(email) == null;
        }
    }
}