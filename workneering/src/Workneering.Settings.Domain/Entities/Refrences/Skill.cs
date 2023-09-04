using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record Skill : RefrenceEntity
    {
        public Skill(string name) : base(name) { }
    }
}
