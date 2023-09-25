using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects.Filters;
public class ClientProjectListFilters : BaseFilterDto
{
    public ProjectStatusEnum? Status { get; set; }
}

