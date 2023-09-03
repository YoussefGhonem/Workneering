using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Language.DeleteLanguage
{
    public class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
    {

        public DeleteLanguageCommandValidator()
        {

            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();


        }

    }
}