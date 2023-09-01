using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVisibility
{
    public class UpdateVisibilityCommandValidator : AbstractValidator<UpdateVisibilityCommand>
    {

        public UpdateVisibilityCommandValidator()
        {
            RuleFor(r => r.Visibility)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}