using Workneering.Base.Helpers.Enums;
using Workneering.User.Domain.Enums;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Application.Queries.Company.GetCompanyBasicDetails
{
    public class CompanyBasicDetailsDto
    {
        public string Name { get; set; }
        public string VatId { get; set; }

        public string Description { get; set; }

        public string WebsiteLink { get; set; }

        public string? TitleOverview { get; set; }

        public string? WhoAreWe { get; set; }

        public string? WhatDoWeDo { get; set; }
        public string? Title { get; set; }

        public int? NumOfReviews { get; set; }

        public decimal? Reviews { get; set; }

        public DateTimeOffset? FoundedIn { get; set; }

        public CompanySizeEnum? CompanySize { get; set; }

        public LocationInfo? Location { get; set; }
        public SpecialtyDto? Specialty { get; set; }


    }
    public class SpecialtyDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }

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
