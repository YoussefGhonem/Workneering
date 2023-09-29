using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record EmploymentHistory : BaseEntity
    {
        private string _title;
        private string _companyName;
        private int? _startYear;
        private int? _endYear;
        private string? _description;
        private string _role; // Area Of Work
        public EmploymentHistory()
        {

        }

        #region public fields
        public string CompanyName { get => _companyName; private set => _companyName = value; }
        public string Title { get => _title; private set => _title = value; }
        public string? Description { get => _description; private set => _description = value; }
        public string? Role { get => _role; private set => _role = value; }
        public int? StartYear { get => _startYear; private set => _startYear = value; }
        public int? EndYear { get => _endYear; private set => _endYear = value; }
        #endregion

        #region public methods
        public void UpdateDescription(string? field)
        {
            _description = field;
        }
        public void UpdateCompanyName(string? field)
        {
            _companyName = field;
        }
        public void UpdateRole(string? field)
        {
            _role = field;
        }
        public void UpdateTitle(string? field)
        {
            _title = field;
        }

        public void UpdateStartDate(int? field)
        {
            _startYear = field;
        }
        public void UpdateEndDate(int? field)
        {
            _endYear = field;
        }
        #endregion

    }
}
