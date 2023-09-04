using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.Skills.UpdateFreelancerSkills
{
    public class UpdateFreelancerSkillsCommand : IRequest<Unit>
    {
        public List<UpdateFreelancerSkillsDto>? FreelancerSkills { get; set; }

    }
    public class UpdateFreelancerSkillsDto
    {
        // Importaaaaaaaaaant
        //Important: need this id from ui to get new skills or delete skills
        //SkillId: this id get from skills Table (refrences schama) i'm already provide you API for Get All skills
        public Guid SkillId { get; set; }
        public string? Name { get; set; }
    }
}
