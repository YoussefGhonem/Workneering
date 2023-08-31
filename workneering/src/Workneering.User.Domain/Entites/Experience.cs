using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record Experience : BaseEntity
    {
        private string _subject;
        private string _description;
        public Experience()
        {

        }
        public Experience(string name, string description)
        {
            _subject = name;
            _description = description;
        }

        public string Subject { get => _subject; private set => _subject = value; }
        public string Description { get => _description; private set => _description = value; }

        public void UpdateSubject(string field)
        {
            _subject = field;
        }
        public void UpdateDescription(string field)
        {
            _description = field;
        }
    }
}
