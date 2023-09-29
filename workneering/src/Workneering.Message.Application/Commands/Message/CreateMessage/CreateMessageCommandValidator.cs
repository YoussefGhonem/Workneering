﻿using FluentValidation;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {

        public CreateMessageCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(r => r.SenderId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.RecipientId)
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