using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.UpdateExperiences
{
    public class UpdateExperienceCommandValidator : AbstractValidator<UpdateExperienceCommand>
    {

        public UpdateExperienceCommandValidator()
        {
            RuleFor(r => r.ExperienceId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Subject)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}