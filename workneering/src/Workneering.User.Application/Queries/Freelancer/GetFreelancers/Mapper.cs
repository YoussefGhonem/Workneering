using Mapster;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Extention;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers
{
    public static class Mapper
    {

        public static void Mapping(IStorageService _storageService)
        {
            TypeAdapterConfig<Domain.Entites.Freelancer, FreelancersListDto>.NewConfig()
                    .Map(dest => dest.ImageDetails.Url, src => src.ImageDetails.Key.SetDownloadFileUrlByKey(_storageService));
        }
    }
}
