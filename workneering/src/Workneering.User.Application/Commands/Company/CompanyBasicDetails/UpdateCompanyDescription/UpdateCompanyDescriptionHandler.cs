﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyDescription
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateCompanyDescriptionCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateCompanyDescriptionCommand request, CancellationToken cancellationToken)
        {

            var query = await _userDatabaseContext.Companies.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
            query!.UpdateOverviewDescription(request.OverviewDescription);
            query!.UpdateAllPointAndPercentage();
            _userDatabaseContext.Companies.Attach(query);
            await _userDatabaseContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
