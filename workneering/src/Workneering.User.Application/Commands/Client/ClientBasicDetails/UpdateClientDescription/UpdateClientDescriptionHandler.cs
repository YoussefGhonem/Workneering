using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientDescription
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateClientDescriptionCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateClientDescriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _userDatabaseContext.Clients.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
                query!.UpdateOverviewDescription(request.OverviewDescription);
                query!.UpdateAllPointAndPercentage();
                _userDatabaseContext.Clients.Attach(query);
                await _userDatabaseContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception e)
            {
                return Unit.Value;
            }



        }
    }
}
