using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhoIAm
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateClientWhoIAmCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateClientWhoIAmCommand request, CancellationToken cancellationToken)
        {
            var query = await _userDatabaseContext.Clients.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
            query!.UpdateWhoIAm(request.WhoIAm);
            query!.UpdateAllPointAndPercentage();
            _userDatabaseContext.Clients.Attach(query);
            await _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
