using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Application.Services.Models;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateClientBasicDetailsCommand, Unit>
    {
        private readonly IDbQueryService _dbQueryService;
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<Unit> Handle(UpdateClientBasicDetailsCommand request, CancellationToken cancellationToken)
        {
            var query = await _userDatabaseContext.Clients.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            query!.UpdateTitle(request.Title);
            query!.UpdateTitleOverview(request.TitleOverview);
            query!.UpdateCategory(request.CategoryId);
            query!.UpdateTitleOverview(request.TitleOverview);
            query!.UpdateGender(request.Gender);

            await _dbQueryService!.UpdateCountryUser(CurrentUser.Id!.Value, request.CountryId, cancellationToken);

            _userDatabaseContext.Clients.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
