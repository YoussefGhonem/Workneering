using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record Certification : BaseEntity
    {
        private string? _name;
        private int _startYear;
        private int _endYear;
        private string? _awardAreaOfStudy;
        private string? _givenBy;
        private string? _description;
        private string? _licence;
        private CertifictionFile _certifictionFile = new();

        public Certification(string? subject, int startDate, int endDate = 0, string? awardAreaOfStudy = null, string? givenBy = null)
        {
            _name = subject;
            _startYear = startDate;
            _endYear = endDate;
            _awardAreaOfStudy = awardAreaOfStudy;
            _givenBy = givenBy;
        }
        public Certification()
        {

        }

        public string? Name { get => _name; private set => _name = value; }
        public string? Licence { get => _licence; private set => _licence = value; }
        public string? Description { get => _description; private set => _description = value; }
        public int StartYear { get => _startYear; private set => _startYear = value; }
        public int EndYear { get => _endYear; private set => _endYear = value; }
        public string? AwardAreaOfStudy { get => _awardAreaOfStudy; private set => _awardAreaOfStudy = value; }
        public string? GivenBy { get => _givenBy; private set => _givenBy = value; }
        public virtual CertifictionFile CertifictionFile => _certifictionFile;

        public void UpdatName(string? field)
        {
            _name = field;
        }
        public void UpdatLicence(string? field)
        {
            _licence = field;
        }
        public void UpdateDescription(string? field)
        {
            _description = field;
        }
        public void UpdateAwardAreaOfStudy(string? field)
        {
            _awardAreaOfStudy = field;
        }
        public void UpdateGivenBy(string? field)
        {
            _givenBy = field;
        }
        public void UpdateLicense(string? field)
        {
            _licence = field;
        }
        public void UpdateStartYear(int field)
        {
            _startYear = field;
        }
        public void UpdateEndYear(int field)
        {
            _endYear = field;
        }

    }
}
