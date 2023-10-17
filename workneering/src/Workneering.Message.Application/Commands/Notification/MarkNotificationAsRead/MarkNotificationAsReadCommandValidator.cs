using FluentValidation;

namespace Workneering.Message.Application.Commands.Notification.MarkNotificationAsRead
{
    public class MarkNotificationAsReadCommandValidator : AbstractValidator<MarkNotificationAsReadCommand>
    {

        public MarkNotificationAsReadCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

        }

    }
}