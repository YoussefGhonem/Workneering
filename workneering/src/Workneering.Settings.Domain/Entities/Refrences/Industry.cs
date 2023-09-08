using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record Industry : BaseEntity
    {
        private string _name;

        public Industry()
        {

        }
        public Industry(string name)
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
