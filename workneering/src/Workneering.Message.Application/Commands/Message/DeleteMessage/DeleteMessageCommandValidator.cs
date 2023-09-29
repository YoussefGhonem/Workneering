using FluentValidation;

namespace Workneering.Message.Application.Commands.Message.DeleteMessage
{
    public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
    {

        public DeleteMessageCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.MessageId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();




        }

    }
}