﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateExperienceLevel;

public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateExperienceLevelCommand, Unit>
{
    private readonly UserDatabaseContext _userDatabaseContext;

    public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
    {
        _userDatabaseContext = userDatabaseContext;
    }
    public async Task<Unit> Handle(UpdateExperienceLevelCommand request, CancellationToken cancellationToken)
    {
        var query = await _userDatabaseContext.Freelancers
                            .Include(c => c.Portfolios).AsSplitQuery()
                            .Include(c => c.Educations).AsSplitQuery()
                            .Include(c => c.Certifications).AsSplitQuery()
                            .Include(c => c.Languages).AsSplitQuery()
                            .Include(c => c.Experiences).AsSplitQuery()
                            .Include(c => c.Categories).AsSplitQuery()
                            .Include(c => c.EmploymentHistory).AsSplitQuery()
                            .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
        query!.UpdateExperienceLevel(request.ExperienceLevel);
        query.UpdateAllPointAndPercentage(query);
        _userDatabaseContext.Freelancers.Attach(query);
        await _userDatabaseContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
