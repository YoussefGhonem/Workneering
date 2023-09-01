using MediatR;
using System.Text.Json.Serialization;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.UpdateExperiences
{
    public class UpdateExperienceCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid ExperienceId { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
    }
}
