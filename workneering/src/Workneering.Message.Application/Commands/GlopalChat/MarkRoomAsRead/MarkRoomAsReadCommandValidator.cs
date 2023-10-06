using FluentValidation;

namespace Workneering.Message.Application.Commands.GlopalChat.MarkRoomAsRead
{
    public class MarkRoomAsReadCommandValidator : AbstractValidator<MarkRoomAsReadCommand>
    {

        public MarkRoomAsReadCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;






        }

    }
}