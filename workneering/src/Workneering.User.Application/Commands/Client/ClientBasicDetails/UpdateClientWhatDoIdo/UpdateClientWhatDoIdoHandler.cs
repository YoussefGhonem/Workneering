using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhatDoIdo
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateClientWhatDoIdoCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateClientWhatDoIdoCommand request, CancellationToken cancellationToken)
        {

            var query = await _userDatabaseContext.Clients.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
            query!.UpdateWhatDoIdo(request.WhatDoIdo);
            query!.UpdateAllPointAndPercentage();
            _userDatabaseContext.Clients.Attach(query);
            await _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
