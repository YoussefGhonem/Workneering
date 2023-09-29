namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForClient
{
    public class GetProjectBasicDetailsForClientDto
    {
        public Guid ClientId { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? ProjectBudgetPrice { get; set; }
        public string? ProjectStatus { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? ProjectBudget { get; set; }
        public string? ProjectType { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
        public List<CategoriesDto>? Categories { get; set; } = new();
        public List<SubCategoriesDto>? SubCategories { get; set; } = new();
        public List<SkillsDto>? Skills { get; set; } = new();
    }

    public class CategoriesDto
    {
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; } = null;
    }
    public class SubCategoriesDto
    {
        public Guid? SubCategoryId { get; set; }
        public string? Name { get; set; } = null;
    }
    public class SkillsDto
    {
        public Guid? SkillId { get; set; }
        public string? Name { get; set; } = null;
    }
}
