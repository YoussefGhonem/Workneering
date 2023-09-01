using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerEducationDetails
{
    public class UpdateFreelancerEducationDetailsCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public int? YearAttended { get; set; }
        public int? YearGraduated { get; set; }
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public string? Description { get; set; }
    }
}
