﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid? ClientId { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public List<IFormFile>? Attachments { get; set; }
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
        public List<Guid>? CategoriesIds { get; set; }
        public List<Guid>? SubCategoriesIds { get; set; }
        public List<Guid>? SkillsIds { get; set; }
    }
    public class CategorizationDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; } = null;
    }
}
