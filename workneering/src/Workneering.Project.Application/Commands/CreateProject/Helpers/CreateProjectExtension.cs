using Mapster;
using Workneering.Project.Domain.Entities;
using Workneering.Project.Domain.ValueObject;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Commands.CreateProject.Helpers
{
    public static class CreateProjectExtension
    {
        public static Domain.Entities.Project CreatProject(this CreateProjectCommand command)
        {
            var projectCategory = command.ProjectCategory.Adapt<ProjectCategory>();
            var clientId = CurrentUser.Id;
            var skills = command.RequiredSkills.Adapt<List<ProjectSkill>>();


            return new Domain.Entities.Project(
                command.ProjectTitle, command.ProjectDescription, command.IsOpenDueDate,
                command.DueDate, command.ProjectBudgetPrice, projectCategory, clientId,
                command.ProjectStatus, command.ExperienceLevel,
                command.ProjectBudget, skills);

        }
    }
}
