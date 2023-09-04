using FluentValidation;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientBasicDetails
{
    public class UpdateClientBasicDetailsCommandValidator : AbstractValidator<UpdateClientBasicDetailsCommand>
    {

        public UpdateClientBasicDetailsCommandValidator()
        {

            RuleFor(r => r.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Gender)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.TitleOverview)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}