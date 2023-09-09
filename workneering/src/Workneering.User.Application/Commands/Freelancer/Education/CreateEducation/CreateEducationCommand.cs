using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.Education.CreateEducation
{
    public class CreateEducationCommand : IRequest<Unit>
    {
        public int? YearAttended { get; set; }
        public int? YearGraduated { get; set; }
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public string? Description { get; set; }
        public string? AreaOfStudy { get; set; }
    }
}
