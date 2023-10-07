using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Message.Application.Commands.Message.MarkMessageAsRead
{
    public class MarkMessageAsReadCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid ProjectId { get; set; }
        public List<Guid>? Ids { get; set; }


    }
}