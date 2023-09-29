using Mapster;
using Workneering.Base.Helpers.Extensions;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Project.Domain.Entities;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Commands.CreateProject.Helpers
{
    public static class CreateProjectExtension
    {
        public static async Task<Domain.Entities.Project> CreatProject(this CreateProjectCommand command, List<CategorizationDto> cat,
            List<CategorizationDto> supca,
            List<CategorizationDto> skil, IStorageService _storageService, CancellationToken cancellationToken)
        {
            var clientId = CurrentUser.Id;

            var categories = cat.AsNotNull().Select(x => new ProjectCategory(x.Id.Value, x.Name)).ToList();
            var subCategories = supca.AsNotNull().Select(x => new ProjectSubCategory(x.Id.Value, x.Name)).ToList();
            var skills = skil.AsNotNull().Select(x => new ProjectSkill(x.Id.Value, x.Name)).ToList();

            TypeAdapterConfig<StoredFile, ProjectAttachment>.NewConfig()
                  .Map(dest => dest.ImageDetails.Key, src => src.Key)
                  .Map(dest => dest.ImageDetails.Extension, src => src.Extension)
                  .Map(dest => dest.ImageDetails.FileName, src => src.FileName)
                  .Map(dest => dest.ImageDetails.FileSize, src => src.FileSize);

            var attachments = await _storageService.UploadFiles(command.Attachments, cancellationToken);
            var attachmentsFileDto = attachments?.Adapt<List<ProjectAttachment>>();

            return new Domain.Entities.Project(attachmentsFileDto,
                subCategories, categories, skills,
                command.HoursPerWeek, command.ProjectDuration, command.ProjectType,
                command.ProjectTitle, command.ProjectDescription, command.IsOpenDueDate,
                command.DueDate, command.ProjectFixedBudgetPrice, clientId,
                command.ProjectStatus, command.ExperienceLevel,
                command.ProjectBudget, command.ProjectHourlyFromPrice, command.ProjectHourlyToPrice, command.IsRecommend);

        }
    }
}
