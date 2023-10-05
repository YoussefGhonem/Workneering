using MediatR;

namespace Workneering.Message.Application.Queries.GetUserInfoForChat
{
    public class GetUserInfoForChatQuery : IRequest<UserInfoForChatDto>
    {
        public Guid RoomId { get; set; }
    }
}
