using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Education.CreateEducation
{
    public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
    {

        public CreateEducationCommandValidator()
        {

            RuleFor(r => r.YearAttended)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.YearGraduated)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.SchoolName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Degree)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}