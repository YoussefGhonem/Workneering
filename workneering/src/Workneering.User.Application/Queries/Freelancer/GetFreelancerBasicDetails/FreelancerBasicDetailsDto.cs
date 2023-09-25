namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class FreelancerBasicDetailsDto
    {
        public bool? TotalJobs { get; set; }
        public bool? IsMarked { get; set; }
        public string? TitleOverview { get; set; }
        public CountryInfo Location { get; set; } = new();
        public UserAddressInfo Address { get; set; } = new();
        public int? NumberOfLanguages { get; set; }
        public int? NumberOfCertification { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public decimal? Reviews { get; set; }
        public int? NumOfReviews { get; set; }
        public int? WengazPercentage { get; set; }
        public int? ProfilePoint { get; set; }
        public int? MonthPoint { get; set; }
        public int? PackagePoint { get; set; }
        public int? DeductedPoint { get; set; }
        public int? WengazPoint { get; set; }
        public decimal? YearsOfExperience { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? Title { get; set; }
        public string? OverviewDescription { get; set; }
        public string? Visibility { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? VideoIntroductionLinkYoutube { get; set; }
        public string? VideoIntroductionTypeOfVideo { get; set; }
        public int? Availability { get; set; }
        public Guid? CategoryId { get; set; }
    }
    public class CountryInfo
    {
        public Guid? Id { get; set; } // country Id
        public string? Name { get; set; }
        public string Flag { get; set; }
    }
    public class UserAddressInfo
    {
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
    }
}
