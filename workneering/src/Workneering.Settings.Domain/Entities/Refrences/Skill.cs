using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record Skill : BaseEntity
    {
        private string _name;

        public Skill()
        {

        }
        public Skill(string name)
        {
            _name = name;
        }
        public string Name { get => _name; private set => _name = value; }

        public void UpdateName(string field)
        {
            Name = field;
        }
    }
}
