using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.Skills.UpdateFreelancerSkills
{
    public class UpdateFreelancerSkillsCommand : IRequest<Unit>
    {
        public List<UpdateSkillsDto>? FreelancerSkills { get; set; }

    }
    public class UpdateSkillsDto
    {
        public Guid Id { get; set; } //Important: need this id from ui to get new skills or delete skills
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
