using MediatR;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyDescription
{
    public class UpdateCompanyDescriptionCommand : IRequest<Unit>
    {
        public string OverviewDescription { get; set; }

    }
}
