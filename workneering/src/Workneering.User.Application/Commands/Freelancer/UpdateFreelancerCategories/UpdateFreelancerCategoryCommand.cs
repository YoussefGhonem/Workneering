using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerCategories
{
    public class UpdateFreelancerCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
