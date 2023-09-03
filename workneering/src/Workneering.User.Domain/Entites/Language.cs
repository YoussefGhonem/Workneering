using Workneering.Base.Domain.Common;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Domain.Entites
{
    public record Language : BaseEntity
    {
        private string _name;
        private LanguageLevelEnum _level;

        public Language(string name, LanguageLevelEnum level)
        {
            _name = name;
            _level = level;
        }
        public Language()
        {

        }
        public string Name { get => _name; private set => _name = value; }
        public LanguageLevelEnum Level { get => _level; private set => _level = value; }


        public void UpdateName(string field)
        {
            _name = field;
        }
        public void UpdateLevel(LanguageLevelEnum field)
        {
            _level = field;
        }
    }
}
