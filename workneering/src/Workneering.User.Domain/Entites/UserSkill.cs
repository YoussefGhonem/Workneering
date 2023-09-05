using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites;
public record UserSkill : BaseEntity
{
    private Guid _skillId;

    public UserSkill(Guid skillId)
    {
        _skillId = skillId;
    }
    public UserSkill()
    {
    }
    public Guid SkillId { get => _skillId; private set => _skillId = value; }

    public void UpdateSkillId(Guid field)
    {
        _skillId = field;
    }

}
