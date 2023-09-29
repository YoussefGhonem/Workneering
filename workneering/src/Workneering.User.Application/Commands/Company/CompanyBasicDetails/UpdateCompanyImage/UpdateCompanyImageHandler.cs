using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Models;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyImage
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateCompanyImageCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<Unit> Handle(UpdateCompanyImageCommand request, CancellationToken cancellationToken)
        {
            var query = await _userDatabaseContext.Companies.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            var storedFiles = await _storageService.Upload(request.Image, cancellationToken: cancellationToken);
            var image = new FileDto()
            {
                Key = storedFiles.Key,
                Extension = storedFiles.Extension,
                FileName = storedFiles.FileName,
                FileSize = storedFiles.FileSize
            };
            query!.UpdateImage(image);
            _userDatabaseContext.Companies.Update(query);
            await _userDatabaseContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
