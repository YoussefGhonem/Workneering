using MediatR;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails
{
    public class GetFreelancerBasicDetailsQuery : IRequest<ProjectBasicDetailsDto>
    {
        public Guid FreelancerId { get; set; }
    }
}
