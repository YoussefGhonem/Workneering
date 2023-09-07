using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateAvailability;

public class UpdateAvailabilityCommandValidator : AbstractValidator<UpdateAvailabilityCommand>
{

    public UpdateAvailabilityCommandValidator()
    {
        RuleFor(r => r.Availability)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();
    }
}