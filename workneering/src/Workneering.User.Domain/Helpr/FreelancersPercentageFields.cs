using Workneering.Base.Helpers.Enums;
using Workneering.User.Domain.Entites;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Domain.Helpr
{
    public class FreelancersPercentageFields
    {
        public string? TitleOverview { get; set; }
        public string? Name { get; set; }
        public GenderEnum? Gender { get; set; }
        public decimal? YearsOfExperience { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? Title { get; set; }
        public string? OverviewDescription { get; set; }
        public ExperienceLevelEnum? ExperienceLevel { get; set; }
        public int? Availability { get; set; }
        public Guid CountryId { get; set; }
        public List<EmploymentHistory> EmploymentHistory { get; set; }
        public List<Education> Educations { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<UserCategory>? Categories { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Language> Languages { get; set; }
    }
}
