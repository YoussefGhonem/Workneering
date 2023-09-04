using Mapster;
using Workneering.Project.Domain.Entities;
using Workneering.Project.Domain.ValueObject;

namespace Workneering.Project.Application.Commands.UpdateProject.Helpers
{
    public static class UpdateProjectExtension
    {
        public static Domain.Entities.Project UpdateProject(this UpdateProjectCommand command, Domain.Entities.Project query)
        {
            var projectCategory = command.ProjectCategory.Adapt<ProjectCategory>();
            var skills = command.RequiredSkills.Adapt<List<ProjectSkill>>();

            query.UpdateDueDate(command.DueDate);
            query.UpdateExperienceLevel(command.ExperienceLevel);
            query.UpdateProjectBudget(command.ProjectBudget);
            query.UpdateProjectDescription(command.ProjectDescription);
            query.UpdateProjectStatus(command.ProjectStatus);
            query.UpdateProjectTitle(command.ProjectTitle);
            query.UpdateProjectType(command.ProjectType);
            query.UpdateIsOpenDueDate(command.IsOpenDueDate);
            query.UpdateProjectBudgetPrice(command.ProjectBudgetPrice);

            query.UpdateFreelancerSkills(skills);
            query.UpdateProjectCategory(projectCategory);

            return query;

        }
    }
}
