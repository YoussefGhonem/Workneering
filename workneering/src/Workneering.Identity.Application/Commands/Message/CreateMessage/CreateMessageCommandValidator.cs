using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Workneering.Base.Application.FluentValidation.Validators;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Identity.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        private readonly UserManager<Domain.Entities.User> _userManager;

        public CreateMessageCommandValidator(UserManager<Domain.Entities.User> userManager)
        {
            _userManager = userManager;
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.SenderId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.RecipientId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



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