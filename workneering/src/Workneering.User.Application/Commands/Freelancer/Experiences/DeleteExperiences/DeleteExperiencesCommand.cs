using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.DeleteExperiences
{
    public class DeleteExperiencesCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid ExperienceId { get; set; }
    }
}
