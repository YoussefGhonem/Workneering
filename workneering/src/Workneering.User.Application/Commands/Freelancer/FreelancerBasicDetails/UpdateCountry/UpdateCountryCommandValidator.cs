using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateCountry
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {

        public UpdateCountryCommandValidator()
        {
            RuleFor(r => r.CountryId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}