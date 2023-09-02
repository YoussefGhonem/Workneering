using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record Certification : BaseEntity
    {
        private string _name;
        private string _passedDate;
        private string _description;
        // here we will add attachments
        public Certification(string subject, string passedDate)
        {
            _name = subject;
            _passedDate = passedDate;
        }
        public Certification()
        {

        }

        public string Name { get => _name; private set => _name = value; }
        public string Description { get => _description; private set => _description = value; }
        public string PassedDate { get => _passedDate; private set => _passedDate = value; }

        public void UpdatName(string field)
        {
            _name = field;
        }
        public void UpdateDescription(string field)
        {
            _description = field;
        }
        public void UpdatePassedDate(string field)
        {
            _passedDate = field;
        }

    }
}
