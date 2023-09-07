using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Settings.Application.Queries.GetSubCategories
{
    public class GetSubCategoriesQuery : IRequest<List<SubCategoriesDrp>>
    {
        public List<Guid>? CategoryIds { get; set; }
    }
}