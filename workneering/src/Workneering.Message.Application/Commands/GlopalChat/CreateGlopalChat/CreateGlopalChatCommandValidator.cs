using FluentValidation;

namespace Workneering.Message.Application.Commands.GlopalChat.CreateGlopalChat
{
    public class CreateGlopalChatCommandValidator : AbstractValidator<CreateGlopalChatCommand>
    {

        public CreateGlopalChatCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.RoomId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}