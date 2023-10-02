using System.Linq;
using Workneering.Base.Helpers.Extensions;
using Workneering.User.Application.Services.DbQueryService;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers.Filters
{
    public static class ApplyFilterExtension
    {
        public static async Task<IQueryable<Domain.Entites.Freelancer>> Filter(
            this IQueryable<Domain.Entites.Freelancer> query, GetFreelancersQuery filters)
        {
            // Filters

            if (filters.CategoryIds is not null)
            {
                query = query.Where(x => x.Categories.Any(x => filters.CategoryIds.Contains(x.Id)));
            }
            if (filters.AvailabilityFrom is not null && filters.AvailabilityTo is not null)
            {
                query = query.Where(x => x.Availability >= filters.AvailabilityFrom && x.Availability <= filters.AvailabilityTo);
            }
            if (filters.AvailabilityFrom is not null && filters.AvailabilityTo is null)
            {
                query = query.Where(x => x.Availability >= filters.AvailabilityFrom);
            }
            if (filters.HourlyRateFrom is not null && filters.HourlyRateTo is not null)
            {
                query = query.Where(x => x.HourlyRate >= filters.HourlyRateFrom && x.HourlyRate <= filters.HourlyRateTo);
            }
            if (filters.HourlyRateFrom is not null && filters.HourlyRateTo is null)
            {
                query = query.Where(x => x.HourlyRate >= filters.HourlyRateFrom);
            }
            if (filters.ExperienceLevels.AsNotNull().Any())
            {
                query = query.Where(x => filters.ExperienceLevels.Contains(x.ExperienceLevel.Value));
            }
            return query;
        }

    }
}
