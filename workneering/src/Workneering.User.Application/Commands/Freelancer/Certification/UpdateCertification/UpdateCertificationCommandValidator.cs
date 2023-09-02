using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Certification.UpdateCertification
{
    public class UpdateCertificationCommandValidator : AbstractValidator<UpdateCertificationCommand>
    {

        public UpdateCertificationCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.PassedDate)
    .Cascade(CascadeMode.Stop)
    .NotNull()
    .NotEmpty();

        }

    }
}