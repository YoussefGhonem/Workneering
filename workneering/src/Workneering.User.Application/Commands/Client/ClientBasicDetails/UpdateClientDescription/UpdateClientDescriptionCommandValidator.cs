using FluentValidation;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientDescription
{
    public class UpdateClientDescriptionCommandValidator : AbstractValidator<UpdateClientDescriptionCommand>
    {

        public UpdateClientDescriptionCommandValidator()
        {
            RuleFor(r => r.OverviewDescription)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}