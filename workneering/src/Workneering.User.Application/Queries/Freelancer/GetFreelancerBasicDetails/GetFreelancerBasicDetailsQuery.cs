using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class GetFreelancerBasicDetailsQuery : IRequest<FreelancerBasicDetailsDto>
    {
        public Guid FreelancerId { get; set; }
    }
}
