using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Certification.CreateCertification
{
    public class CreateCertificationCommandValidator : AbstractValidator<CreateCertificationCommand>
    {

        public CreateCertificationCommandValidator()
        {

            RuleFor(r => r.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.PassedDate)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}