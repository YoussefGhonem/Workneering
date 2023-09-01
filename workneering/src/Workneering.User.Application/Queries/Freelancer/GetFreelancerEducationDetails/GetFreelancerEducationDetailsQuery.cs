using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerEducationDetails
{
    public class GetFreelancerEducationDetailsQuery : IRequest<EducationDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
