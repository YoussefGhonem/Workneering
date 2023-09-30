using StackExchange.Redis;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.Project.GetProjects
{
    public class ProjectListDto
    {
        public Guid Id { get; set; }
        public bool IsSaved { get; set; } = false;
        public bool IsApplied { get; set; } = false;
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public ProjectBudgetEnum? ProjectBudget { get; set; }
        public decimal? ProjectFixedBudgetPrice { get; set; }
        public decimal? ProjectHourlyFromPrice { get; set; }
        public decimal? ProjectHourlyToPrice { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset CreatedDateProposal { get; set; }
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? ProjectBudgetPrice { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? ProjectDuration { get; set; }
        public List<CategoriesDto>? Categories { get; set; } = new();
        public List<SubCategoriesDto>? SubCategories { get; set; } = new();
        public List<SkillsDto>? Skills { get; set; } = new();
        public ClientDetailsDto Client { get; set; } = new();
    }
    public class ClientDetailsDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Title { get; set; } = null;
        public string? ImageUrl { get; set; } = null;
        public string? CountryName { get; set; } = null;
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
