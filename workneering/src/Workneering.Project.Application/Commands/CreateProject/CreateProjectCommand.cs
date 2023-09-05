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
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? ProjectBudgetPrice { get; set; }
        public HoursPerWeekEnum? HoursPerWeek { get; set; }
        public ProjectDurationEnum? ProjectDuration { get; set; }
        public ProjectStatusEnum? ProjectStatus { get; set; }
        public ExperienceLevelEnum? ExperienceLevel { get; set; }
        public ProjectBudgetEnum? ProjectBudget { get; set; }
        public ProjectTypeEnum? ProjectType { get; set; }
        public List<CreateProjectSkillDto> RequiredSkills { get; set; } = new();
        public CreateProjectCategoryDto? ProjectCategory { get; set; } = new();
    }
}
