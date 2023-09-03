using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerEducationDetails
{
    public class GetEducationsQuery : IRequest<List<EducationListDto>>
    {
    }
}
