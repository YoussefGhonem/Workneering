using Workneering.Base.Domain.Common;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Domain.Entites
{
    public record Language : BaseEntity
    {
        private Guid? _languageId; // Data Seeding
        private LanguageLevelEnum? _level;


        public Language()
        {

        }
        public Guid? LanguageId { get => _languageId; private set => _languageId = value; }
        public LanguageLevelEnum? Level { get => _level; private set => _level = value; }

        public void UpdateLanguageId(Guid id)
        {
            _languageId = id;
        }
        public void UpdateLanguageId(Guid? field)
        {
            _languageId = field;
        }
        public void UpdateLevel(LanguageLevelEnum? field)
        {
            _level = field;
        }
    }
}
