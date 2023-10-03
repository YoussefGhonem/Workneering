using FluentValidation;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {

        public CreateMessageCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.ProjectId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}