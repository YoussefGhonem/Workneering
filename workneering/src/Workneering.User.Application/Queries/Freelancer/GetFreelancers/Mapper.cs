using Mapster;
using Workneering.Base.Helpers.Extensions;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Extention;
using Workneering.User.Application.Services.DbQueryService;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers
{
    public static class Mapper
    {
        public static void Mapping(IStorageService _storageService, IDbQueryService _dbQueryService, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<Domain.Entites.Freelancer, FreelancersListDto>.NewConfig()
            .Map(dest => dest.ImageDetails.Url, src => src.ImageDetails.Key.SetDownloadFileUrlByKey(_storageService))
            .Map(dest => dest.CountryName, src => _dbQueryService.GetCountryInfoByUserId(src.Id, cancellationToken).Result.Name)
            .Map(dest => dest.Flag, src => _dbQueryService.GetCountryInfoByUserId(src.Id, cancellationToken).Result.Flag)
            .Map(dest => dest.Categories, src => _dbQueryService.GetCategoriesAsync(src.Categories.AsNotNull().Any() ? src.Categories.AsNotNull().Select(x => x.CategoryId) : null, cancellationToken).Result.Categories);


        }
    }
}
