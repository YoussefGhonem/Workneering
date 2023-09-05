namespace Workneering.Project.Application.Queries.Project.GetProjects
{
    public class ProjectListDto
    {
        public Guid Id { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? ProjectBudgetPrice { get; set; }
        public string? ProjectStatus { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? ProjectBudget { get; set; }
        public string? ProjectType { get; set; }
    }
}
