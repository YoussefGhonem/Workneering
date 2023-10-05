using MediatR;
using System.Text.Json.Serialization;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Message.Application.Queries.GlopalChat.GetGlopalChat
{
    public class GetGlopalChatQuery : IRequest<PaginationResult<GlopalChatDto>>
    {
        [JsonIgnore]
        public Guid RoomId { get; set; }
        public int Hand { get; set; }
        public int Next { get; set; }
    }
}
