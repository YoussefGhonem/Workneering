using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Message.Application.Commands.Message.DeleteMessage
{
    public class DeleteMessageCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid MessageId { get; set; }


    }
}