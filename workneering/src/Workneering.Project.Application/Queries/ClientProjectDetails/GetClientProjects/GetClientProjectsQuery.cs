using MediatR;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects.Filters;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects
{
    public class GetClientProjectsQuery : ClientProjectListFilters, IRequest<PaginationResult<ClientProjectsDto>>
    {

    }
}
