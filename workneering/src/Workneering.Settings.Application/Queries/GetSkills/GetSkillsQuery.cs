using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Settings.Application.Queries.GetSkills
{
    public class GetSkillsQuery : IRequest<List<SkillsDrp>>
    {
        public List<Guid>? SubCategoryIds { get; set; }
    }
}