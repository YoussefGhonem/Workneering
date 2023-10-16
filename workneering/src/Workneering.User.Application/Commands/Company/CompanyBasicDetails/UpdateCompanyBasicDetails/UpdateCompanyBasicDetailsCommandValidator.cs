using FluentValidation;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyBasicDetails
{
    public class UpdateCompanyBasicDetailsCommandValidator : AbstractValidator<UpdateCompanyBasicDetailsCommand>
    {

        public UpdateCompanyBasicDetailsCommandValidator()
        {

            RuleFor(r => r.FoundedIn)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            //RuleFor(r => r.Title)
            //    .Cascade(CascadeMode.Stop)
            //    .NotNull()
            //    .NotEmpty();

            RuleFor(r => r.TitleOverview)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.CompanySize)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}