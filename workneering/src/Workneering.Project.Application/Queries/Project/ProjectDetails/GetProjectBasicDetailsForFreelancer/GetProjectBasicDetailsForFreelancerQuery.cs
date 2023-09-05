using MediatR;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForFreelancer
{
    public class GetProjectBasicDetailsForFreelancerQuery : IRequest<ProjectBasicDetailsForFreelancerDto>
    {
        public Guid ProjectId { get; set; }
    }
}
