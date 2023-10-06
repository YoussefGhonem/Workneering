using FluentValidation;

namespace Workneering.Message.Application.Commands.GlopalChat.MarkRoomAsRead
{
    public class MarkRoomAsReadCommandValidator : AbstractValidator<MarkRoomAsReadCommand>
    {

        public MarkRoomAsReadCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.Ids)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();




        }

    }
}