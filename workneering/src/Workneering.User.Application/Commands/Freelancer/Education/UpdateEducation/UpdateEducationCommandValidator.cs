using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Education.UpdateEducation
{
    public class UpdateEducationCommandValidator : AbstractValidator<UpdateEducationCommand>
    {

        public UpdateEducationCommandValidator()
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