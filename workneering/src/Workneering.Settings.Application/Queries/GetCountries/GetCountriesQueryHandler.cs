using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, PaginationResult<CountriesDto>>
    {
        private readonly SettingsDbContext _context;

        public GetCountriesQueryHandler(SettingsDbContext context)
        {
            _context = context;
        }

        public async Task<PaginationResult<CountriesDto>> Handle(GetCountriesQuery request,
            CancellationToken cancellationToken)
        {
            var paginationResult = await _context.Countries.AsNoTracking().Filter(request).Sort(request)
                .PaginateAsync(request.PageSize, request.PageNumber, cancellationToken);

            var dataList = paginationResult.list.Adapt<List<CountriesDto>>();

            return new PaginationResult<CountriesDto>(dataList, paginationResult.total);
        }
    }
}