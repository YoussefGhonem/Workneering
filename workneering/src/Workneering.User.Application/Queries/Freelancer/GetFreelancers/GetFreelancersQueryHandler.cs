using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Application.Queries.Freelancer.GetFreelancers.Filters;
using Workneering.Packages.Storage.AWS3.Services;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers
{
    public class GetFreelancersQueryHandler : IRequestHandler<GetFreelancersQuery, PaginationResult<FreelancersListDto>>
    {
        private readonly UserDatabaseContext _context;
        private readonly IDbQueryService _dbQueryService;
        private readonly IStorageService _storageService;

        public GetFreelancersQueryHandler(UserDatabaseContext context, IDbQueryService dbQueryService, IStorageService storageService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
            _storageService = storageService;
        }
        public async Task<PaginationResult<FreelancersListDto>> Handle(GetFreelancersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _context.Freelancers
                .Include(x => x.Categories)
                .AsNoTracking()
                .OrderByDescending(a => a.CreatedDate)
                .AsQueryable()
                .Filter(request);

                var dataQuery = await query.PaginateAsync(request.PageSize, request.PageNumber, cancellationToken: cancellationToken);
                Mapper.Mapping(_storageService, _dbQueryService, cancellationToken);

                var result = dataQuery.list.Adapt<List<FreelancersListDto>>();

                return new PaginationResult<FreelancersListDto>(result.ToList(), dataQuery.total);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
