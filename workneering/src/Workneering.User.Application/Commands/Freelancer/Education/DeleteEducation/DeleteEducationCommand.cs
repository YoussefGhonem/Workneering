using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Education.DeleteEducation
{
    public class DeleteEducationCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
