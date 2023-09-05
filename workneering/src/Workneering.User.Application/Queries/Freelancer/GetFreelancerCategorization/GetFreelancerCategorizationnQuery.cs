using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategorization
{
    public class GetFreelancerCategorizationnQuery : IRequest<FreelancerCategorizationDto>
    {
        public Guid FreelancerId { get; set; }
    }
}
