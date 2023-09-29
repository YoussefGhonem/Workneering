using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Queries.Company.GetCompanyBasicDetails
{
    public class CompanyBasicDetailsDto
    {
        public string Name { get; set; }
        public string VatId { get; set; }

        public string Description { get; set; }
        public string? ImageUrl { get; set; }


        public string WebsiteLink { get; set; }

        public string? TitleOverview { get; set; }

        public string? WhoAreWe { get; set; }

        public string? WhatDoWeDo { get; set; }
        public string? Title { get; set; }
        public int? NumOfReviews { get; set; }
        public decimal? Reviews { get; set; }
        public DateTimeOffset? FoundedIn { get; set; }
        public CompanySizeEnum? CompanySize { get; set; }
        public Guid? CategoryId { get; set; }
        public int WengazPercentage { get; set; }
        public int ProfilePoint { get; set; }
        public int MonthPoint { get; set; }
        public int PackagePoint { get; set; }
        public int DeductedPoint { get; set; }
        public int WengazPoint { get; set; }
        public CountryInfo Location { get; set; } = new();
        public UserAddressInfo Address { get; set; } = new();

    }
    public class CountryInfo
    {
        public Guid? Id { get; set; } // country Id
        public string? Name { get; set; }
        public string? Flag { get; set; }
    }
    public class UserAddressInfo
    {
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
    }
}
