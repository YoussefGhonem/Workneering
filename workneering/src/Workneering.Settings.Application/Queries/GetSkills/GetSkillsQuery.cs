using MediatR;

namespace Workneering.Settings.Application.Queries.GetSkills
{
    public class GetSkillsQuery : IRequest<List<SkillsDrp>>
    {
        public List<Guid>? SubCategoryIds { get; set; }
    }
}