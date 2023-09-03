using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetEducations
{
    public class GetEducationsQuery : IRequest<List<EducationListDto>>
    {
        public Guid? FreelancerId { get; set; }

    }
}
