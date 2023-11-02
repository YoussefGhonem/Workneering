using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Extention;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetCertifications
{
    public class GetCertificationsQueryHandler : IRequestHandler<GetCertificationsQuery, List<CertificationListDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;

        public GetCertificationsQueryHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<List<CertificationListDto>> Handle(GetCertificationsQuery request, CancellationToken cancellationToken)
        {


            TypeAdapterConfig<CertifictionAttachment, ImageDetailsDto>.NewConfig()
                              .Map(dest => dest.Key, src => src.FileDetails.Key)
                              .Map(dest => dest.FileName, src => src.FileDetails.FileName);
            var query = _userDatabaseContext.Freelancers.Include(x => x.Certifications).ThenInclude(x => x.CertifictionAttachment).FirstOrDefault(x => x.Id == request.FreelancerId);
            var result = query!.Certifications.Adapt<List<CertificationListDto>>();
            foreach (var item in result)
            {
                item.CertifictionAttachment.Url = item.CertifictionAttachment.Key.SetDownloadFileUrlByKey(_storageService);
            }
            return result;
        }
    }
}