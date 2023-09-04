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
            var query = await _userDatabaseContext.Companies.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            query!.UpdateWebsiteLink(request.WebsiteLink);
            query!.UpdateCompanySize(request.CompanySize);
            query!.UpdateFoundedIn(request.FoundedIn);
            query!.UpdateName(request.Name);
            query!.UpdateTitle(request.Title);
            query!.UpdateTitleOverview(request.TitleOverview);
            query!.UpdateSpecialtyId(request.SpecialtyId);
            query!.UpdateVatId(request.VatId);

            var mapping = request.Location.Adapt<UserAddressDetailsDto>();
            mapping.CountryId = request.Location.Id;
            _dbQueryService!.UpdateOnAddressUser(CurrentUser.Id.Value, mapping, cancellationToken);

            _userDatabaseContext.Companies.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
