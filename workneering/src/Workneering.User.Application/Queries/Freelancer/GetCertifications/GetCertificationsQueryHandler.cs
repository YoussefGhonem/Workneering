﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetCertifications
{
    public class GetCertificationsQueryHandler : IRequestHandler<GetCertificationsQuery, List<CertificationListDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetCertificationsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<CertificationListDto>> Handle(GetCertificationsQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return new List<CertificationListDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.Certifications).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = query!.Certifications.Adapt<List<CertificationListDto>>();
            return result;
        }
    }
}
