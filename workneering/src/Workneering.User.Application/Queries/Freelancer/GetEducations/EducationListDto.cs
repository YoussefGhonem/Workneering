namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerEducationDetails
{
    public class EducationListDto
    {
        public Guid Id { get; set; }
        public int? YearAttended { get; set; }
        public int? YearGraduated { get; set; }
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public string? Description { get; set; }
    }
}
