using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Certification.UpdateCertification
{
    public class UpdateCertificationHandler : IRequestHandler<UpdateCertificationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;

        public UpdateCertificationHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<Unit> Handle(UpdateCertificationCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Certifications).FirstOrDefault(x => x.Id == CurrentUser.Id);

            TypeAdapterConfig<StoredFile, CertifictionAttachment>.NewConfig()
                          .Map(dest => dest.FileDetails.Key, src => src.Key)
                          .Map(dest => dest.FileDetails.Extension, src => src.Extension)
                          .Map(dest => dest.FileDetails.FileName, src => src.FileName)
                          .Map(dest => dest.FileDetails.FileSize, src => src.FileSize);

            var uploadAttatchment = await _storageService.Upload(request.CertifictionFile);
            var newAttachment = uploadAttatchment?.Adapt<CertifictionAttachment>();

            var result = request.Adapt<Domain.Entites.Certification>();
            query.UpdateCertification(request.Id, result, newAttachment);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
