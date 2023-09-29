using MediatR;

namespace Workneering.Identity.Application.Queries.Message.GetConversation
{
    public class GetConversationQuery : IRequest<List<GetConversationDto>>
    {
        public Guid RecipientId { get; set; }

    }
}
