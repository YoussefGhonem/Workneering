using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Extention;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetFreelancerPortfolios
{
    public class GetFreelancerPortfoliosQueryHandler : IRequestHandler<GetFreelancerPortfoliosQuery, List<FreelancerPortfolioDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;

        public GetFreelancerPortfoliosQueryHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<List<FreelancerPortfolioDto>> Handle(GetFreelancerPortfoliosQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers
                .Include(x => x.Portfolios)
                .ThenInclude(x => x.PortfolioFiles)
                .FirstOrDefault(x => x.Id == request.FreelancerId);


            TypeAdapterConfig<PortfolioFile, ImageDetailsDto>.NewConfig()
                          .Map(dest => dest.Key, src => src.FileDetails.Key)
                          .Map(dest => dest.Extension, src => src.FileDetails.Extension)
                          .Map(dest => dest.Url, src => src.FileDetails.SetDownloadFileUrl(_storageService))
                          .Map(dest => dest.FileName, src => src.FileDetails.FileName);

            var result = query!.Portfolios.Adapt<List<FreelancerPortfolioDto>>();
            var PortfolioFiles = result!.SelectMany(x => x.PortfolioFiles);

            foreach (var item in PortfolioFiles)
            {
                item.Url = item.Key.SetDownloadFileUrlByKey(_storageService);
            }
            return result;


        }
    }
}
