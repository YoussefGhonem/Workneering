using MediatR;

namespace Workneering.User.Application.Queries.Client.GetClientCategorization
{
    public class GetClientCategorizationQuery : IRequest<ClientCategorizationDto>
    {
        public Guid ClientId { get; set; }
    }
}
