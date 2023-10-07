using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Message.Application.Commands.GlopalChat.MarkRoomAsRead
{
    public class MarkRoomAsReadCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid RoomId { get; set; }
        public List<Guid>? Ids { get; set; }


    }
}