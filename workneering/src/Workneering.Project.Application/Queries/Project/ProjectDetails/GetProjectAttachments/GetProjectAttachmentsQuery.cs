using MediatR;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectAttachments
{
    public class GetProjectAttachmentsQuery : IRequest<List<ProjectAttachmentsDto>>
    {
        public Guid ProjectId { get; set; }
    }
}
