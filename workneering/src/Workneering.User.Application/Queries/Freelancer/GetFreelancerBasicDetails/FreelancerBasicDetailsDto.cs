﻿using Workneering.Base.Helpers.Enums;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class FreelancerBasicDetailsDto
    {
        public bool? TotalJobs { get; set; }
        public bool? IsMarked { get; set; }
        public string? TitleOverview { get; set; }
        public LocationInfo? Location { get; set; }
        public int? NumberOfLanguages { get; set; }
        public int? NumberOfCertification { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public decimal? Reviews { get; set; }
        public int? NumOfReviews { get; set; }
        public decimal? YearsOfExperience { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? Title { get; set; }
        public string? OverviewDescription { get; set; }
        public string? Visibility { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? VideoIntroductionLinkYoutube { get; set; }
        public string? VideoIntroductionTypeOfVideo { get; set; }
        public string? AvailabilityHoursPerWeek { get; set; }
        public DateTimeOffset? AvailabilityDateForNewWork { get; set; }
        public bool? AvailabilityContractToHire { get; set; } = false;
    }
    public class LocationInfo
    {
        public Guid Id { get; set; } // country Id
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
