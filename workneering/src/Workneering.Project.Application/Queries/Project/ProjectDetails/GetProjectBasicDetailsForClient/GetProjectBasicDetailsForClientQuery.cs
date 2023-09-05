using MediatR;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForClient
{
    public class GetProjectBasicDetailsForClientQuery : IRequest<GetProjectBasicDetailsForClientDto>
    {
        public Guid ProjectId { get; set; }
    }
}
