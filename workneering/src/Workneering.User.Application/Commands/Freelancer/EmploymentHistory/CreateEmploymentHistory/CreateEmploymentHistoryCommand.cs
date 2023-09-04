using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.CreateEmploymentHistory
{
    public class CreateEmploymentHistoryCommand : IRequest<Unit>
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Role { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
    }
}
