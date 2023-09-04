using MediatR;
using Workneering.Base.Helpers.Enums;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientBasicDetails
{
    public class UpdateClientBasicDetailsCommand : IRequest<Unit>
    {
        public Guid? CategoryId { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? TitleOverview { get; set; }
        public string? Title { get; set; }
        public int? NumOfReviews { get; set; }
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
