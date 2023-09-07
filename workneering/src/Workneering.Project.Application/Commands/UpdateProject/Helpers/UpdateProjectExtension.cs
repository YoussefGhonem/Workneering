using Mapster;

namespace Workneering.Project.Application.Commands.UpdateProject.Helpers
{
    public static class UpdateProjectExtension
    {
        public static Domain.Entities.Project UpdateProject(this UpdateProjectCommand command, Domain.Entities.Project query)
        {


            var Categories = command.Categories.Adapt<List<Domain.Entities.ProjectCategory>>();
            var SubCategories = command.SubCategories.Adapt<List<Domain.Entities.ProjectSubCategory>>();
            var Skills = command.SubCategories.Adapt<List<Domain.Entities.ProjectSkill>>();

            query.UpdateProjectDurationDescription(command.DueDate);
            query.UpdateProjectDuration(command.ProjectDuration);
            query.UpdateExperienceLevel(command.ExperienceLevel);
            query.UpdateProjectBudget(command.ProjectBudget);
            query.UpdateProjectDescription(command.ProjectDescription);
            query.UpdateHoursPerWeek(command.HoursPerWeek);
            query.UpdateProjectStatus(command.ProjectStatus);
            query.UpdateProjectTitle(command.ProjectTitle);
            query.UpdateProjectType(command.ProjectType);
            query.UpdateIsOpenDueDate(command.IsOpenDueDate);
            query.UpdateIsRecommend(command.IsRecommend);

            query.UpdateProjectBudgetPrice(command.ProjectFixedBudgetPrice);
            query.UpdateHourlyToPrice(command.ProjectHourlyToPrice);
            query.UpdateHourlyFromPrice(command.ProjectHourlyFromPrice);

            query.UpdateSkills(Skills);
            query.UpdateCategory(Categories);
            query.UpdateSubCategory(SubCategories);

            return query;

        }
    }
}
