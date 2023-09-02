using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Certification.DeleteCertification
{
    public class DeleteCertificationCommandValidator : AbstractValidator<DeleteCertificationCommand>
    {

        public DeleteCertificationCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }
    }
}