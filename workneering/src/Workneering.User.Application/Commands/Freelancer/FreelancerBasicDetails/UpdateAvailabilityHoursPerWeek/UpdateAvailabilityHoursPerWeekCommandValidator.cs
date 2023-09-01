using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateAvailabilityHoursPerWeek
{
    public class UpdateAvailabilityHoursPerWeekCommandValidator : AbstractValidator<UpdateAvailabilityHoursPerWeekCommand>
    {

        public UpdateAvailabilityHoursPerWeekCommandValidator()
        {
            RuleFor(r => r.HoursPerWeek)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.DateForNewWork)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}