using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Models;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Certification.CreateCertification
{
    public class CreateCertificationHandler : IRequestHandler<CreateCertificationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IStorageService _storageService;


        public CreateCertificationHandler(UserDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<Unit> Handle(CreateCertificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _userDatabaseContext.Freelancers
                                 .Include(c => c.Portfolios)
                                 .Include(c => c.Educations)
                                 .Include(c => c.Certifications)
                                 .Include(c => c.Languages)
                                 .Include(c => c.Experiences)
                                 .Include(c => c.Categories)
                                 .Include(c => c.EmploymentHistory)
                                 .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id);
                TypeAdapterConfig<StoredFile, CertifictionAttachment>.NewConfig()
                      .Map(dest => dest.FileDetails.Key, src => src.Key)
                      .Map(dest => dest.FileDetails.Extension, src => src.Extension)
                      .Map(dest => dest.FileDetails.FileName, src => src.FileName)
                      .Map(dest => dest.FileDetails.FileSize, src => src.FileSize);

                var uploadAttatchment = await _storageService.Upload(request.CertifictionFile);
                var attachmentsFileDto = uploadAttatchment?.Adapt<CertifictionAttachment>();
                var result = request.Adapt<Domain.Entites.Certification>();
                var certification = new Domain.Entites.Certification(request.Name, request.StartYear, request.EndYear, request.AwardAreaOfStudy, request.GivenBy, attachmentsFileDto);
                query!.AddCertification(certification);
                query.UpdateAllPointAndPercentage(query);
                _userDatabaseContext.Freelancers.Attach(query);
                await _userDatabaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return Unit.Value;
        }
    }
}
