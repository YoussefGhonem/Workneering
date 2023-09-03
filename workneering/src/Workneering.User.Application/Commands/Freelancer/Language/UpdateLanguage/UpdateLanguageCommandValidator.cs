using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Language.CreateLanguage
{
    public class CreateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {

        public CreateLanguageCommandValidator()
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