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
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? ProjectBudgetPrice { get; set; }
        public ProjectStatusEnum? ProjectStatus { get; set; }
        public ExperienceLevelEnum? ExperienceLevel { get; set; }
        public ProjectBudgetEnum? ProjectBudget { get; set; }
        public ProjectTypeEnum? ProjectType { get; set; }
        public List<UpdateProjectSkillDto> RequiredSkills { get; set; } = new();
        public UpdateProjectCategoryDto? ProjectCategory { get; set; } = new();
    }
}
