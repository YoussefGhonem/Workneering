using MediatR;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetails
{
    public class GetProjectBasicDetailsForFreelancerQuery : IRequest<ProjectBasicDetailsForFreelancerDto>
    {
        public Guid ProjectId { get; set; }
    }
}
