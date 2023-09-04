using MediatR;

namespace Workneering.User.Application.Queries.Client.GetClientBasicDetails
{
    public class GetClientBasicDetailsQuery : IRequest<ClientBasicDetailsDto>
    {
        public Guid ClientId { get; set; }
    }
}
