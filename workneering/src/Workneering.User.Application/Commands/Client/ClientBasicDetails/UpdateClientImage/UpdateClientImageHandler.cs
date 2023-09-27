using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Models;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientImage
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateClientImageCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<Unit> Handle(UpdateClientImageCommand request, CancellationToken cancellationToken)
        {
            var query = await _userDatabaseContext.Clients.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            var storedFiles = await _storageService.Upload(request.Image, cancellationToken: cancellationToken);
            var image = new FileDto()
            {
                Key = storedFiles.Key,
                Extension = storedFiles.Extension,
                FileName = storedFiles.FileName,
                FileSize = storedFiles.FileSize
            };
            query!.UpdateImage(image);
            _userDatabaseContext.Clients.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
