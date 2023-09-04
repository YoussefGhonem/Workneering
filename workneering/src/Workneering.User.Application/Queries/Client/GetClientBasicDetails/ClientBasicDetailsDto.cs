using Workneering.Base.Helpers.Enums;

namespace Workneering.User.Application.Queries.Client.GetClientBasicDetails
{
    public class ClientBasicDetailsDto
    {
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Description { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? TitleOverview { get; set; }
        public string? Title { get; set; }
        public int? NumOfReviews { get; set; }
        public decimal? Reviews { get; set; }
        public LocationInfo? Location { get; set; }
    }
    public class LocationInfo
    {
        public Guid? Id { get; set; } // country Id
        public string? Name { get; set; }
        public string Flag { get; set; }
        public string? Language { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
    }
}
