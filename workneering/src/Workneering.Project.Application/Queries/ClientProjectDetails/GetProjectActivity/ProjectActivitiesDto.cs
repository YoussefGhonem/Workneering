using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectActivity
{
    public class ProjectActivitiesDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ClassStyleName { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
