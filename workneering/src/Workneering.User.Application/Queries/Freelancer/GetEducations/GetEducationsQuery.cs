using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerEducationDetails
{
    public class GetFreelancerEducationDetailsQuery : IRequest<List<EducationListDto>>
    {
    }
}
