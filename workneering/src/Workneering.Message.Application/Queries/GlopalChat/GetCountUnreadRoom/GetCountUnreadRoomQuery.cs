using MediatR;

namespace Workneering.Message.Application.Queries.GlopalChat.GetCountUnreadRoom
{
    public class GetCountUnreadRoomQuery : IRequest<CountUnreadRoomDto>
    {
        public Guid RoomId { get; set; }
    }
}
