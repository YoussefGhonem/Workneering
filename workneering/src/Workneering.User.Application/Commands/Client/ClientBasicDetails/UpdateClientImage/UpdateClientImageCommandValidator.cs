using FluentValidation;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientImage
{
    public class UpdateClientImageCommandValidator : AbstractValidator<UpdateClientImageCommand>
    {

        public UpdateClientImageCommandValidator()
        {
            RuleFor(r => r.Image)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}