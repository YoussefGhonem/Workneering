using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Models;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.UpdatePortfolio
{
    public class UpdateFreelancerPortfolioHandler : IRequestHandler<UpdateFreelancerPortfolioCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;

        public UpdateFreelancerPortfolioHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<Unit> Handle(UpdateFreelancerPortfolioCommand request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<StoredFile, PortfolioFile>.NewConfig()
                          .Map(dest => dest.FileDetails.Key, src => src.Key)
                          .Map(dest => dest.FileDetails.Extension, src => src.Extension)
                          .Map(dest => dest.FileDetails.FileName, src => src.FileName)
                          .Map(dest => dest.FileDetails.FileSize, src => src.FileSize);
            var query = _userDatabaseContext.Freelancers.Include(x => x.Portfolios)
                .FirstOrDefault(x => x.Id == CurrentUser.Id);

            var uploadAttatchment = await _storageService.UploadFiles(request.PortfolioFiles, cancellationToken);
            var newAttachments = uploadAttatchment?.Adapt<List<PortfolioFile>>();

            var portfolioMap = request.Adapt<Domain.Entites.Portfolio>();

            query!.UpdatePortfolio(request.Id, portfolioMap, newAttachments, request.ImageKyes);

            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);

            return Unit.Value;


        }
    }
}
