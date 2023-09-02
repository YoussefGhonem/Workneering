using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record Language : BaseEntity
    {
        private string _name;
        private string _level;

        public Language(string name, string level)
        {
            _name = name;
            _level = level;
        }
        public Language()
        {

        }
        public string Name { get => _name; private set => _name = value; }
        public string Level { get => _level; private set => _level = value; }


        public void UpdateName(string field)
        {
            _name = field;
        }
        public void UpdateLevel(string field)
        {
            _level = field;
        }
    }
}
