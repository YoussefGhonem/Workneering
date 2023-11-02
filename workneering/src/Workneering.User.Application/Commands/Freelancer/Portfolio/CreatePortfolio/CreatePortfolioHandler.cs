using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Models;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.CreatePortfolio
{
    public class CreatePortfolioHandler : IRequestHandler<CreatePortfolioCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;
        public CreatePortfolioHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<Unit> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var query = await _userDatabaseContext.Freelancers
                                        .Include(c => c.Portfolios).AsSplitQuery()
                                        .Include(c => c.Educations).AsSplitQuery()
                                        .Include(c => c.Certifications).AsSplitQuery()
                                        .Include(c => c.Languages).AsSplitQuery()
                                        .Include(c => c.Experiences).AsSplitQuery()
                                        .Include(c => c.Categories).AsSplitQuery()
                                        .Include(c => c.EmploymentHistory).AsSplitQuery()
                                        .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            TypeAdapterConfig<StoredFile, PortfolioFile>.NewConfig()
                  .Map(dest => dest.FileDetails.Key, src => src.Key)
                  .Map(dest => dest.FileDetails.Extension, src => src.Extension)
                  .Map(dest => dest.FileDetails.FileName, src => src.FileName)
                  .Map(dest => dest.FileDetails.FileSize, src => src.FileSize);

            var uploadAttatchment = await _storageService.UploadFiles(request.PortfolioFiles, cancellationToken);
            var attachmentsFileDto = uploadAttatchment?.Adapt<List<PortfolioFile>>();
            var portfolioMap = request.Adapt<Domain.Entites.Portfolio>();

            var portfolio = new Domain.Entites.Portfolio(request.ProjectTitle, request.StartYear,
                request.EndYear, request.ProjectDescription, attachmentsFileDto);

            query.AddPortfolio(portfolio);
            query.UpdateAllPointAndPercentage(query);
            _userDatabaseContext?.Freelancers.Attach(query);
            await _userDatabaseContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
