using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerSkills
{
    public class UpdateFreelancerSkillsCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
