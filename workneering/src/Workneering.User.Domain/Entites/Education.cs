using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record Education : BaseEntity
    {
        private string? _schoolName;
        private int? _yearAttended;
        private int? _yearGraduated;
        private string? _degree;
        private string? _description;
        public Education()
        {
            // Parameterless constructor
        }
        public Education(string? school, int yearAttended, int yearGraduated, string? degree, string? description)
        {
            _schoolName = school;
            _yearAttended = yearAttended;
            _yearGraduated = yearGraduated;
            _degree = degree;
            _description = description;
        }
        public int? YearAttended { get => _yearAttended; private set => _yearAttended = value; }
        public int? YearGraduated { get => _yearGraduated; private set => _yearGraduated = value; }
        public string? SchoolName { get => _schoolName; private set => _schoolName = value; }
        public string? Degree { get => _degree; private set => _degree = value; }
        public string? Description { get => _description; private set => _description = value; }

        public void UpdateSchool(string? field)
        {
            if (string.IsNullOrWhiteSpace(field)
                || string.Equals(_schoolName, field, StringComparison.CurrentCultureIgnoreCase)) return;

            _schoolName = field;
        }
        public void UpdateYearAttended(int? field)
        {
            _yearAttended = field;
        }
        public void UpdateYearGraduated(int? field)
        {
            _yearGraduated = field;
        }
        public void UpdateDegree(string? field)
        {
            _degree = field;
        }
        public void UpdateDescription(string? field)
        {
            _description = field;
        }
    }
}
