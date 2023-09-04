using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Queries.Freelancer.GetEmploymentHistory
{
    public class EmploymentHistoryDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Role { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
    }
}
