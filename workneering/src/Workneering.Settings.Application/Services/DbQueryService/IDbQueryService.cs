using Workneering.Settings.Application.Services.Models;

namespace Workneering.Settings.Application.Services.DbQueryService;

public interface IDbQueryService
{
    public List<SubcategoryDetailsDto> GetSkillsBuSubCategoriesIds(List<Guid>? subcategoryIds, int pageSize = 10, int pageNumber = 1);

}