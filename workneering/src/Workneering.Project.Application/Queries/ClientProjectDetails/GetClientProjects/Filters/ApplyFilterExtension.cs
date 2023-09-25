using System.Linq.Dynamic.Core;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects.Filters
{
    public static class ApplyFilterExtension
    {
        public static IQueryable<Domain.Entities.Project> Filter(
            this IQueryable<Domain.Entities.Project> query, GetClientProjectsQuery filters)
        {
            // Filters  
            if (filters.Status is not null)
            {
                query = query.Where(x => x.ProjectStatus == filters.Status);
            }
            return query;
        }
    }
}
