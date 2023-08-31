using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Workneering.Base.Application.FluentValidation.Helpers;

namespace Workneering.Base.Application.FluentValidation.Validators
{
    public class PasswordValidator : AbstractValidator<string>
    {
        private readonly PasswordOptions _passwordOptions;

        public PasswordValidator()
        {
            _passwordOptions = IdentitySettings.PasswordOptions();

            RuleFor(b => b)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(_passwordOptions.RequiredLength)
                .WithMessage($"Your password length must be at least {_passwordOptions.RequiredLength}")
                .MaximumLength(200).WithMessage("Your password length must exceed 200.")
                .Matches("[A-Z]").WithMessage("Your password must contain at least one uppercase letter.")
                .When(a => _passwordOptions.RequireUppercase)
                .Matches("[a-z]").WithMessage("Your password must contain at least one lowercase letter.")
                .When(a => _passwordOptions.RequireLowercase)
                .Matches("[0-9]").WithMessage("Your password must contain at least one number.")
                .When(a => _passwordOptions.RequireDigit)
                .Matches("[^a-zA-Z0-9]").WithMessage("Your password must contain at least non Alphanumeric")
                .When(a => _passwordOptions.RequireNonAlphanumeric)
                .Must(RepeatChar)
                .WithMessage(
                    $"Your password mustn't contain {_passwordOptions.RequiredUniqueChars} or more repeated character");
        }

        private bool RepeatChar(string password)
        {
            return !password.ToLower().GroupBy(x => x).Any(x => x.Count() >= _passwordOptions.RequiredUniqueChars);
        }

        /// <summary>
        /// we can use this method to check if the password containing sequence string
        /// </summary>
        /// <param name="password"></param>
        /// <returns>boolean value</returns>
        private bool IsInSequence(string password)
        {
            return !password.Where((t, i) => t == password[i + 1] - 1).Any();
        }
    }
}