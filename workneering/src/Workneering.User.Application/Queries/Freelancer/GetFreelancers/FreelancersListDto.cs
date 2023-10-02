using Workneering.User.Application.Queries.Client.GetClientCategorization;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers
{
    public class FreelancersListDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsMarked { get; set; }
        public ImageDetailsDto? ImageDetails { get; set; }
        public string? TitleOverview { get; set; }
        public string? Gender { get; set; }
        public decimal? Reviews { get; set; }
        public int? NumOfReviews { get; set; }
        public decimal? YearsOfExperience { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? Title { get; set; }
        public string? ExperienceLevel { get; set; }
        public List<LookupDto>? Categories { get; set; } = new();
        public string? CountryName { get; set; }
    }
    public class ImageDetailsDto
    {
        public string? Url { get; set; }
        public string? Key { get; set; }
        public string? FileName { get; set; }
        public string? Extension { get; set; }
        public long? FileSize { get; set; }
    }
}
