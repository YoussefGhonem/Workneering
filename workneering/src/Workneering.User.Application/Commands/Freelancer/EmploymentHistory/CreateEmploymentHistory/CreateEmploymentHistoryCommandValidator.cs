using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.CreateEmploymentHistory
{
    public class CreateEmploymentHistoryCommandValidator : AbstractValidator<CreateEmploymentHistoryCommand>
    {

        public CreateEmploymentHistoryCommandValidator()
        {

            RuleFor(r => r.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.EndYear)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.StartYear)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Role)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}