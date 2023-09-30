using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
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

            var uploadAttatchment = await _storageService.UploadFiles(request.PortfolioFiles, cancellationToken);
            var attachmentsFileDto = uploadAttatchment?.Adapt<List<FileDto>>();
            var portfolioMap = request.Adapt<Domain.Entites.Portfolio>();
            foreach (var item in portfolioMap.PortfolioFiles)
            {
                item.UpdateFiles(attachmentsFileDto);
            }
            query!.AddPortfolio(portfolioMap);
            query.UpdateAllPointAndPercentage(query);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
