using MediatR;

namespace Workneering.Message.Application.Queries.Message.GetConversation
{
    public class GetConversationQuery : IRequest<List<GetConversationDto>>
    {
        public Guid RecipientId { get; set; }

    }
}
