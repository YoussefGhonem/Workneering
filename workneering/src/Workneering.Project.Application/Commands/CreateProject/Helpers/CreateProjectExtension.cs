using Workneering.Base.Helpers.Extensions;
using Workneering.Project.Domain.Entities;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Commands.CreateProject.Helpers
{
    public static class CreateProjectExtension
    {
        public static Domain.Entities.Project CreatProject(this CreateProjectCommand command)
        {
            var clientId = CurrentUser.Id;
            var categories = command.Categories.AsNotNull().Select(x => new ProjectCategory(x.Id.Value, x.Name)).ToList();
            var subCategories = command.SubCategories.AsNotNull().Select(x => new ProjectSubCategory(x.Id.Value, x.Name)).ToList();
            var skills = command.Skills.AsNotNull().Select(x => new ProjectSkill(x.Id.Value, x.Name)).ToList();


            return new Domain.Entities.Project(
                subCategories, categories, skills,
                command.HoursPerWeek, command.ProjectDuration,
                command.ProjectTitle, command.ProjectDescription, command.IsOpenDueDate,
                command.DueDate, command.ProjectFixedBudgetPrice, clientId,
                command.ProjectStatus, command.ExperienceLevel,
                command.ProjectBudget, command.ProjectHourlyFromPrice, command.ProjectHourlyToPrice, command.IsRecommend);

        }
    }
}
