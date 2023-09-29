using MediatR;

namespace Workneering.Identity.Application.Queries.Message.GetConversation
{
    public class GetConversationQuery : IRequest<GetConversationDto>
    {
        public Guid RecipientId { get; set; }

    }
}
