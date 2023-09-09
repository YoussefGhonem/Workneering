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
            var query = await _userDatabaseContext.Companies.Include(x => x.Categories)
                                 .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            query!.UpdateWebsiteLink(request.WebsiteLink);
            query!.UpdateCompanySize(request.CompanySize);
            query!.UpdateFoundedIn(request.FoundedIn);
            query!.UpdateTitle(request.Title);
            query!.UpdateIndustryId(request.IndustryId);
            query!.UpdateTitleOverview(request.TitleOverview);

            await _dbQueryService!.UpdateCountryUser(CurrentUser.Id!.Value, request.CountryId, cancellationToken);

            _userDatabaseContext.Companies.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
