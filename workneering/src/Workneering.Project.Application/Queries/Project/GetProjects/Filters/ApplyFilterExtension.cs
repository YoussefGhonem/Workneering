using Mapster;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Queries.Project.GetProjects.Filters
{
    public static class ApplyFilterExtension
    {
        public static IQueryable<Domain.Entities.Project> Filter(
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
                query = query.Where(x => x.ProjectType == filters.ProjectType);
            }
            if (filters.ProjectBudget is not null)
            {
                query = query.Where(x => x.ProjectBudget == filters.ProjectBudget);
            }
            if (filters.CountriesId.Any())
            {
                var projects = _dbQueryService.GetProjectsByLocations(filters.CountriesId, filters.PageSize, filters.PageNumber);
                var list = projects.Adapt<List<Domain.Entities.Project>>();
                query = list.AsQueryable();
            }
            if (filters.CategoryIds.Any())
            {
                query = query.Where(x => x.Categories.Any(x => filters.CategoryIds.Contains(x.CategoryId)));
            }
            if (filters.NumberOfProposals != null)
            {
                query = query.Where(p => p.Proposals.Count() >= filters.NumberOfProposals.From && p.Proposals.Count() <= filters.NumberOfProposals.To);
            }

            // Sort
            if (!filters.ApplySort) query = query.OrderByDescending(x => x.CreatedDate);
            else
            {
                switch (filters.SortedBy)
                {
                    case SortedByEnum.Newest:
                        query = query.OrderByDescending(x => x.CreatedDate);
                        break;
                    case SortedByEnum.Relevance:
                        var categoryId = _dbQueryService.GetUserCategoryId(CurrentUser.Id!.Value);
                        query = query.OrderByDescending(x => x.Categories.Where(x => categoryId.Contains(x.CategoryId)));
                        break;
                    case SortedByEnum.CleintRating:
                        var projects = _dbQueryService.GetProjectsSortedByClientRating(CurrentUser.Id!.Value, filters.PageSize, filters.PageNumber);
                        var list = projects.Adapt<List<Domain.Entities.Project>>();
                        query = list.AsQueryable();
                        break;
                }
            }

            return query;
        }

    }
}
