using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Project.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

    }
}
