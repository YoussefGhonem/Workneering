using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateHourlyRate
{
    public class UpdateHourlyRateCommandValidator : AbstractValidator<UpdateHourlyRateCommand>
    {

        public UpdateHourlyRateCommandValidator()
        {
            RuleFor(r => r.HourlyRate)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}