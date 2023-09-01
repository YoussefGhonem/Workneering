using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class GetFreelancerEducationDetailsQuery : IRequest<EducationDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
