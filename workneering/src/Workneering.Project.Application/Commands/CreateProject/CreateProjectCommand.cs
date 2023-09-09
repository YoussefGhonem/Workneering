using MediatR;
using System.Text.Json.Serialization;
using Workneering.Project.Application.Commands.CreateProject.Models;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid? ClientId { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public ProjectStatusEnum? ProjectStatus { get; set; }
        public ProjectTypeEnum? ProjectType { get; set; }
        public bool? IsRecommend { get; set; }

        // scope of project
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public ProjectDurationEnum? ProjectDuration { get; set; }
        public ExperienceLevelEnum? ExperienceLevel { get; set; }
        public HoursPerWeekEnum? HoursPerWeek { get; set; }

        //buget
        public ProjectBudgetEnum? ProjectBudget { get; set; }
        public decimal? ProjectFixedBudgetPrice { get; set; }
        public decimal? ProjectHourlyFromPrice { get; set; }
        public decimal? ProjectHourlyToPrice { get; set; }

        // list 
        public List<CategorizationDto>? CategoriesList { get; set; }
        public List<CategorizationDto>? SubCategoriesList { get; set; }
        public List<CategorizationDto>? SkillsList { get; set; }
    }

    public class CategorizationDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; } = null;
    }
}
