using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;
using Workneering.User.Application.Services.DbQueryService;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers
{
    public class GetFreelancersQueryHandler : IRequestHandler<GetFreelancersQuery, PaginationResult<FreelancersListDto>>
    {
        private readonly UserDatabaseContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancersQueryHandler(UserDatabaseContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<FreelancersListDto>> Handle(GetFreelancersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _context.Freelancers.AsNoTracking()
                    .OrderByDescending(a => a.CreatedDate)
                    .AsQueryable()
                    .Filter(request, _dbQueryService);

                var dataQuery = await query.PaginateAsync(request.PageSize, request.PageNumber);

                Mapper.Mapping(_dbQueryService);
                var result = dataQuery.list.Adapt<List<ProjectListDto>>();


                return new PaginationResult<ProjectListDto>(result.ToList(), dataQuery.total);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
