using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Language.UpdateLanguage
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {

        public UpdateLanguageCommandValidator()
        {

            RuleFor(r => r.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Level)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}