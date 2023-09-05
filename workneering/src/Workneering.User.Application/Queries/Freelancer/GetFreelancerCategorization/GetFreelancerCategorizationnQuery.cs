using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetClientCategorization
{
    public class GetFreelancerCategorizationnQuery : IRequest<FreelancerCategorizationDto>
    {
        public Guid FreelancerId { get; set; }
    }
}
