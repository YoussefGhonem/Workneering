using Mapster;
using System.Linq;
using Workneering.Base.Helpers.Extensions;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Domain.Enums;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Queries.Project.GetProjects.Filters
{
    public static class ApplyFilterExtension
    {
        public static async Task<IQueryable<Domain.Entities.Project>> Filter(
            this IQueryable<Domain.Entities.Project> query, GetProjectsQuery filters, IDbQueryService _dbQueryService)
        {
            // Filters

            if (filters.ClientId is not null)
            {
                query = query.Where(x => x.ClientId == filters.ClientId);
            }
            if (filters.IsWishlist)
            {
                query = query.Where(x => x.Wishlist.Any(x => x.FreelancerId == CurrentUser.Id.Value));
            }
            if (filters.SearchWord is not null)
            {
                query = query.Where(x => x.ProjectTitle.Contains(filters.SearchWord) || x.ProjectDescription.Contains(filters.SearchWord));
            }
            if (filters.ProjectType is not null)
            {
                query = query.Where(x => filters.ProjectType.Contains(x.ProjectType.Value));
            }
            if (filters.HoursPerWeek is not null)
            {
                query = query.Where(x => filters.HoursPerWeek.Contains(x.HoursPerWeek.Value));
            }
            if (filters.ProjectDuration is not null)
            {
                query = query.Where(x => filters.ProjectDuration.Contains(x.ProjectDuration.Value));
            }
            if (filters.IsFixed && filters.IsHourly)
            {
                query = query.Where(x => x.ProjectBudget == ProjectBudgetEnum.Fixed || x.ProjectBudget == ProjectBudgetEnum.Hourly);
            }
            if (filters.IsFixed && filters.IsHourly == false)
            {
                query = query.Where(x => x.ProjectBudget == ProjectBudgetEnum.Fixed);
            }
            if (filters.IsFixed == false && filters.IsHourly)
            {
                query = query.Where(x => x.ProjectBudget == ProjectBudgetEnum.Hourly);
            }
            if (filters.CountriesId.AsNotNull().Any())
            {
                var projects = _dbQueryService.GetProjectsByLocations(filters.CountriesId, filters.PageSize, filters.PageNumber);
                var list = projects.Adapt<List<Domain.Entities.Project>>();
                query = list.AsQueryable();
            }
            if (filters.CategoryIds.AsNotNull().Any())
            {
                query = query.Where(x => x.Categories.AsNotNull().Any(x => filters.CategoryIds.AsNotNull().Contains(x.CategoryId)));
            }
            if (filters.NumberOfProposals != null)
            {
                query = query.Where(p => p.Proposals.Count() >= filters.NumberOfProposals.From && p.Proposals.Count() <= filters.NumberOfProposals.To);
            }
            try
            {
                switch (filters.SortedBy)
                {
                    case SortedByEnum.Newest:
                        query = query.OrderByDescending(x => x.CreatedDate);
                        break;
                    case SortedByEnum.Relevance:
                        var categoryIds = await _dbQueryService.GetUserCategoryId(CurrentUser.Id!.Value);
                        query = query.OrderByDescending(p => p.Categories
                                        .Where(x => categoryIds.Contains(x.CategoryId)).Any());
                        break;
                    case SortedByEnum.CleintRating:
                        var projects = _dbQueryService.GetProjectsSortedByClientRating(CurrentUser.Id!.Value, filters.PageSize, filters.PageNumber);
                        var list = projects.Adapt<List<Domain.Entities.Project>>();
                        query = list.AsQueryable();
                        break;
                }

            }
            catch (Exception ex)
            {

                throw;
            }



            return query;
        }

    }
}
