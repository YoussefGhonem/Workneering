using FluentValidation;

namespace Workneering.Message.Application.Commands.Message.MarkMessageAsRead
{
    public class MarkMessageAsReadCommandValidator : AbstractValidator<MarkMessageAsReadCommand>
    {

        public MarkMessageAsReadCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.MessageId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();




        }

    }
}