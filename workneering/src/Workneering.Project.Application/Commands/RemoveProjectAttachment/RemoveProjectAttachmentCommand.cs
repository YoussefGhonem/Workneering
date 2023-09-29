using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Project.Application.Commands.RemoveProjectAttachment
{
    public class RemoveProjectAttachmentCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid ProjectId { get; set; }
        public string Key { get; set; }
    }
}
