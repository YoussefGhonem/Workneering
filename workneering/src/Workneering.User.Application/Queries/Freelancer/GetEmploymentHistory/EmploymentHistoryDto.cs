using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Queries.Freelancer.GetEmploymentHistory
{
    public class EmploymentHistoryDto
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Location Location { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool IsCurrentlyWork { get; set; }
    }
}
