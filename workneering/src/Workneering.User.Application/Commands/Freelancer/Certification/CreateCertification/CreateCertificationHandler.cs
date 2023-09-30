using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Models;
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
            var query = await _userDatabaseContext.Freelancers
                             .Include(c => c.Portfolios).AsSplitQuery()
                             .Include(c => c.Educations).AsSplitQuery()
                             .Include(c => c.Certifications).AsSplitQuery()
                             .Include(c => c.Languages).AsSplitQuery()
                             .Include(c => c.Experiences).AsSplitQuery()
                             .Include(c => c.Categories).AsSplitQuery()
                             .Include(c => c.EmploymentHistory).AsSplitQuery()
                             .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken) ;

            var uploadAttatchment = await _storageService.Upload(request.CertifictionFile, cancellationToken);
            var attachmentsFileDto = uploadAttatchment?.Adapt<FileDto>();
            var result = request.Adapt<Domain.Entites.Certification>();
            result.CertifictionFile.UpdateFile(attachmentsFileDto);
            query!.AddCertification(result);
            query.UpdateAllPointAndPercentage(query);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
