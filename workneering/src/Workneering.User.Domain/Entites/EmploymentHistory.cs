using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Domain.Entites
{
    public record EmploymentHistory : BaseEntity
    {
        private string _companyName;
        private string _title;
        private string? _description;
        private Location _location;
        private DateTimeOffset _startDate;
        private DateTimeOffset? _endDate;
        private bool _isCurrentlyWork;

        public EmploymentHistory(string companyName, string title, Location location, DateTimeOffset startDate, DateTimeOffset endDate, bool currentlyWork, string? description)
        {
            _companyName = companyName;
            _title = title;
            _description = description;
            _location = location;
            _startDate = startDate;
            _endDate = endDate;
            _isCurrentlyWork = currentlyWork;
        }

        #region public fields
        public string CompanyName { get => _companyName; private set => _companyName = value; }
        public string Title { get => _title; private set => _title = value; }
        public string? Description { get => _description; private set => _description = value; }
        public Location Location { get => _location; private set => _location = value; }
        public DateTimeOffset StartDate { get => _startDate; private set => _startDate = value; }
        public DateTimeOffset? EndDate { get => _endDate; private set => _endDate = value; }
        public bool IsCurrentlyWork { get => _isCurrentlyWork; private set => _isCurrentlyWork = value; }
        #endregion

        #region public methods
        public void UpdateDescription(string field)
        {
            _description = field;
        }
        public void UpdateCompanyName(string field)
        {
            _companyName = field;
        }
        public void UpdateTitle(string field)
        {
            _title = field;
        }
        public void UpdateLocation(Location field)
        {
            _location = field;
        }
        public void UpdateStartDate(DateTimeOffset field)
        {
            _startDate = field;
        }
        public void UpdateEndDate(DateTimeOffset field)
        {
            _endDate = field;
        }
        public void UpdateIsCurrentlyWork(bool field)
        {
            _isCurrentlyWork = field;
        }
        #endregion

    }
}
