using MediatR;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.CreateExperience
{
    public class CreateExperienceCommand : IRequest<Unit>
    {
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
