using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateFreelancerCategorization
{
    public class UpdateFreelancerCategorizationCommand : IRequest<Unit>
    {
        public List<Guid> CategoryIds { get; set; }
        public List<Guid> SubCategoryIds { get; set; }
        public List<Guid> SkillIds { get; set; }

    }

}
