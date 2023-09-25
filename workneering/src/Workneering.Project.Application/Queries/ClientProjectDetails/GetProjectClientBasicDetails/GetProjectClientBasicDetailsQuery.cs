using MediatR;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectClientBasicDetails
{
    public class GetProjectClientBasicDetailsQuery : IRequest<ProjectClientBasicDetailsDto>
    {
        public Guid ProjectId { get; set; }
    }
}
