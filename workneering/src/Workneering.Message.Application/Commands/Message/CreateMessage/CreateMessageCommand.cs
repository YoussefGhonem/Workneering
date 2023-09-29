using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid SenderId { get; set; }
        [JsonIgnore]
        public Guid RecipientId { get; set; }
        public string Content { get; set; }

    }
}