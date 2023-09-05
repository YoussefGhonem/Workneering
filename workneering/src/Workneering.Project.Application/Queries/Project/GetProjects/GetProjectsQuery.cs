using MediatR;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Queries.Project.GetProjects.Filters;

namespace Workneering.Project.Application.Queries.Project.GetProjects
{
    public class GetProjectsQuery : ProjectsListFilters, IRequest<PaginationResult<ProjectListDto>>
    {
        public Guid? ProjectId { get; set; }
    }
}
