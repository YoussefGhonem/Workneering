using Mapster;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Project.Domain.Entities;
using Workneering.Shared.Core.Extention;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectAttachments
{
    public static class Mapper
    {
        public static void Mapping(IStorageService _storageService)
        {
            TypeAdapterConfig<ProjectAttachment, ProjectAttachmentsDto>.NewConfig()
                .Map(dest => dest.Key, src => src.ImageDetails.Key)
                .Map(dest => dest.FileName, src => src.ImageDetails.FileName)
                .Map(dest => dest.Extension, src => src.ImageDetails.Extension)
                .Map(dest => dest.CreatedDate, src => src.CreatedDate)
                .Map(dest => dest.Url, src => src.ImageDetails.SetDownloadFileUrl(_storageService))
                .Map(dest => dest.FileSize, src => src.ImageDetails.FileSize);

        }
    }
}
