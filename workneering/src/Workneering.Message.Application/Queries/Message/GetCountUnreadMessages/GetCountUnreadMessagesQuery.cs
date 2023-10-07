using MediatR;

namespace Workneering.Message.Application.Queries.Message.GetCountUnreadMessages
{
    public class GetCountUnreadMessagesQuery : IRequest<CountUnreadMessagesDto>
    {
        public Guid ProjectId { get; set; }
    }
}
