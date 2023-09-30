using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectActivity
{
    public class GetProjectActivitiesQuery : BaseFilterDto, IRequest<PaginationResult<ProjectActivitiesDto>>
    {
        public Guid ProjectId { get; set; }
    }
}
