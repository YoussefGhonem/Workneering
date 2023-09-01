using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateOverviewDescription
{
    public class UpdateOverviewDescriptionCommandValidator : AbstractValidator<UpdateOverviewDescriptionCommand>
    {

        public UpdateOverviewDescriptionCommandValidator()
        {
            RuleFor(r => r.OverviewDescription)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}