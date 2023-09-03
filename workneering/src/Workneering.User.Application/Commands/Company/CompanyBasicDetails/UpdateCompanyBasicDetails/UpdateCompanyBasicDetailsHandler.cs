using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Application.Services.Models;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateCompanyBasicDetailsCommand, Unit>
    {
        private readonly IDbQueryService _dbQueryService;
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<Unit> Handle(UpdateCompanyBasicDetailsCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Companies.Any(x => x.Id != CurrentUser.Id)) return Unit.Value;
            var query = await _userDatabaseContext.Companies.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            query!.UpdateWebsiteLink(request.WebsiteLink);
            query!.UpdateCompanySize(request.CompanySize.Value);
            query!.UpdateFoundedIn(request.FoundedIn.Value);
            query!.UpdateName(request.Name);
            query!.UpdateTitle(request.Title);
            query!.UpdateTitleOverview(request.TitleOverview);
            query!.UpdateSpecialtyId(request.SpecialtyId.Value);
            query!.UpdateVatId(request.VatId);

            var mapping = request.Location.Adapt<UserAddressDetailsDto>();
            _dbQueryService!.UpdateOnAddressUser(CurrentUser.Id.Value, mapping, cancellationToken);

            _userDatabaseContext.Companies.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
