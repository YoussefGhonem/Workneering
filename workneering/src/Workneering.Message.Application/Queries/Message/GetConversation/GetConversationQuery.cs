using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Message.Application.Queries.Message.GetConversation
{
    public class GetConversationQuery : IRequest<PaginationResult<GetConversationDto>>
    {
        public Guid ProjectId { get; set; }

        public int Hand { get; set; }
        public int Next { get; set; }
    }
}
