using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyBasicDetails
{
    public class UpdateCompanyBasicDetailsCommand : IRequest<Unit>
    {
        public string? WebsiteLink { get; set; }
        public string? TitleOverview { get; set; }
        public string? Title { get; set; }
        public DateTimeOffset? FoundedIn { get; set; }
        public CompanySizeEnum? CompanySize { get; set; }
        public Guid? CategoryId { get; set; }
        public LocationInfo? Location { get; set; }
    }

    public class LocationInfo
    {
        public Guid Id { get; set; } // country Id
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
    }

}
