using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Settings.Application.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoriesDrp>>
    {

    }
}