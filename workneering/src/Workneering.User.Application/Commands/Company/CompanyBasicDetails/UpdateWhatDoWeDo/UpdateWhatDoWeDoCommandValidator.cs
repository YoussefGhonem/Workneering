using FluentValidation;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateWhatDoWeDo
{
    public class UpdateWhatDoWeDoCommandValidator : AbstractValidator<UpdateWhatDoWeDoCommand>
    {

        public UpdateWhatDoWeDoCommandValidator()
        {
            RuleFor(r => r.WhatDoWeDo)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}