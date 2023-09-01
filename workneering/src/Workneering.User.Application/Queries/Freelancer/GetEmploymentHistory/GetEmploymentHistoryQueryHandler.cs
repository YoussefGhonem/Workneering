using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetEmploymentHistory
{
    public class GetEmploymentHistoryQueryHandler : IRequestHandler<GetEmploymentHistoryQuery, List<EmploymentHistoryDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetEmploymentHistoryQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<EmploymentHistoryDto>> Handle(GetEmploymentHistoryQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return new List<EmploymentHistoryDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.EmploymentHistory).FirstOrDefault(x => x.Id == request.Id);
            var result = query!.EmploymentHistory.Adapt<List<EmploymentHistoryDto>>();
            return result;
        }
    }
}
