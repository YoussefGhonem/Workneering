using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.UpdateExperiences
{
    public class UpdateExperienceCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
    }
}
