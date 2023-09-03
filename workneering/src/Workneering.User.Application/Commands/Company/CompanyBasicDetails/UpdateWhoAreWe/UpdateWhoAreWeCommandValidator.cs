using FluentValidation;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateWhoAreWe
{
    public class UpdateWhoAreWeCommandValidator : AbstractValidator<UpdateWhoAreWeCommand>
    {

        public UpdateWhoAreWeCommandValidator()
        {
            RuleFor(r => r.WhoAreWe)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}