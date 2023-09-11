using FluentValidation;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhatDoIdo
{
    public class UpdateClientWhatDoIdoCommandValidator : AbstractValidator<UpdateClientWhatDoIdoCommand>
    {

        public UpdateClientWhatDoIdoCommandValidator()
        {
            RuleFor(r => r.WhatDoIdo)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}