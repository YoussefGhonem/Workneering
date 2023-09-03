using System.Linq.Dynamic.Core;
using Workneering.Settings.Domain.Entities;

namespace Workneering.Settings.Application.Queries.GetCountries;

public static class FilterAndSortExtension
{
    public static IQueryable<Country> Filter(
        this IQueryable<Country> query, GetCountriesQuery filters)
    {
        // Filters

        if (!string.IsNullOrWhiteSpace(filters.Name))
        {
            query = query.Where(x => filters.Name.Contains(x.Name) || x.Name.Contains(filters.Name));
        }

        if (filters.IsActive is not null)
        {
            if (filters.IsActive.Value)
            {
                query = query.Where(x => x.IsActive == true);
            }

            if (!filters.IsActive.Value)
            {
                query = query.Where(x => x.IsActive == false);
            }
        }

        return query;
    }

    public static IQueryable<Country> Sort(
        this IQueryable<Country> query, GetCountriesQuery filters)
    {
        //Sorting
        if (string.IsNullOrWhiteSpace(filters.SortField))
        {
            query = query.OrderByDescending(x => x.CreatedDate);
        }
        else
        {
            query = query.OrderBy($"{filters.SortField} {filters.GetSortOrder()}");
        }

        return query;
    }
}