using Workneering.Base.Domain.Common;
using Workneering.User.Domain.Enums;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Entites
{
    public record Freelancer : BaseEntity
    {
        private decimal _hourlyRate;
        private string _title;
        private string _overviewDescription;
        private ExperienceLevelEnum _experienceLevel;
        private VisibilityEnum _visibility;
        private VideoIntroduction _videoIntroduction;
        private Availability _availability;
        private readonly List<Education> _educations = new();
        private List<Portfolio> _portfolios = new();
        private List<FreelancerSkill> _freelancerSkills = new();
        private List<Certification> _certification = new();
        private List<EmploymentHistory> _employmentHistory = new();
        private List<Experience> _experiences = new();
        private List<Category> _categories = new();
        public Freelancer()
        {

        }
        public Freelancer(Guid id)
        {
            Id = id;
        }

        #region public fields
        public decimal HourlyRate { get => _hourlyRate; private set => _hourlyRate = value; }
        public string Title { get => _title; private set => _title = value; }
        public string OverviewDescription { get => _overviewDescription; private set => _overviewDescription = value; }
        public VisibilityEnum Visibility { get => _visibility; private set => _visibility = value; }
        public ExperienceLevelEnum ExperienceLevel { get => _experienceLevel; private set => _experienceLevel = value; }
        public VideoIntroduction VideoIntroduction { get => _videoIntroduction; private set => _videoIntroduction = value; }
        public Availability Availability { get => _availability; private set => _availability = value; }
        public List<Experience> Experiences => _experiences;
        public List<Education> Educations => _educations;
        public List<Portfolio> Portfolios => _portfolios;
        public List<FreelancerSkill> FreelancerSkills => _freelancerSkills;
        public List<Certification> Certifications => _certification;
        public List<EmploymentHistory> EmploymentHistory => _employmentHistory;
        public List<Category> Categories => _categories;

        #endregion

        #region public methods
        public void UpdateOverviewDescription(string field)
        {
            _overviewDescription = field;
        }
        public void UpdateTitle(string field)
        {
            _title = field;
        }
        public void UpdateHourlyRate(VisibilityEnum field)
        {
            _visibility = field;
        }
        public void UpdateOverviewDescription(ExperienceLevelEnum field)
        {
            _experienceLevel = field;
        }
        public void AddCategory(List<Category> data)
        {
            _categories.AddRange(data);
        }
        public void AddEmploymentHistory(List<EmploymentHistory> data)
        {
            _employmentHistory.AddRange(data);
        }
        public void AddCertifications(List<Certification> data)
        {
            _certification.AddRange(data);
        }
        public void AddFreelancerSkills(List<FreelancerSkill> data)
        {
            _freelancerSkills.AddRange(data);
        }
        public void AdEducations(List<Education> data)
        {
            _educations.AddRange(data);
        }
        public void AddPortfolios(List<Portfolio> data)
        {
            _portfolios.AddRange(data);
        }
        public void AddExperiences(List<Experience> data)
        {
            _experiences.AddRange(data);
        }
        #endregion
    }
}
