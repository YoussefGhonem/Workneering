﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetLanguages
{
    public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, List<LanguagesListDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetLanguagesQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<LanguagesListDto>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers.Include(x => x.Languages).FirstOrDefault(x => x.Id == request.FreelancerId);
            var result = query!.Languages.Adapt<List<LanguagesListDto>>();
            return result;
        }
    }
}
