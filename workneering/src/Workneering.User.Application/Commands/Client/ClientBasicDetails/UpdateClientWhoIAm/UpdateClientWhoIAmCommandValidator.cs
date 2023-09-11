using FluentValidation;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhoIAm
{
    public class UpdateClientWhoIAmCommandValidator : AbstractValidator<UpdateClientWhoIAmCommand>
    {

        public UpdateClientWhoIAmCommandValidator()
        {
            RuleFor(r => r.WhoIAm)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}