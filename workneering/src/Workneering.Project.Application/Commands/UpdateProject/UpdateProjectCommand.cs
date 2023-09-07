using MediatR;
using System.Text.Json.Serialization;
using Workneering.Project.Application.Commands.CreateProject.Models;
using Workneering.Project.Application.Commands.UpdateProject.Models;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid? ClientId { get; set; }
        public bool? IsRecommend { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? ProjectFixedBudgetPrice { get; set; }
        public decimal? ProjectHourlyFromPrice { get; set; }
        public decimal? ProjectHourlyToPrice { get; set; }
        public ProjectDurationEnum? ProjectDuration { get; set; }
        public HoursPerWeekEnum? HoursPerWeek { get; set; }
        public ProjectStatusEnum? ProjectStatus { get; set; }
        public ExperienceLevelEnum? ExperienceLevel { get; set; }
        public ProjectBudgetEnum? ProjectBudget { get; set; }
        public ProjectTypeEnum? ProjectType { get; set; }
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
