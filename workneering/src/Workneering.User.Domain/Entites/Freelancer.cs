using Workneering.Base.Domain.Common;
using Workneering.User.Domain.Enums;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Entites
{
    public record Freelancer : BaseEntity
    {
        private decimal? _hourlyRate;
        private string? _title;
        private string? _overviewDescription;
        private ExperienceLevelEnum? _experienceLevel;
        private VisibilityEnum? _visibility;
        private VideoIntroduction? _videoIntroduction = new();
        private Availability? _availability = new();
        private readonly List<Education> _educations = new();
        private readonly List<Portfolio> _portfolios = new();
        private readonly List<FreelancerSkill> _freelancerSkills = new();
        private readonly List<Certification> _certification = new();
        private readonly List<EmploymentHistory> _employmentHistory = new();
        private readonly List<Experience> _experiences = new();
        private readonly List<Category> _categories = new();
        private readonly List<Language> Languages = new();
        public Freelancer()
        {

        }
        public Freelancer(Guid id)
        {
            Id = id;
        }

        #region public fields
        public decimal? HourlyRate { get => _hourlyRate; private set => _hourlyRate = value; }
        public string? Title { get => _title; private set => _title = value; }
        public string? OverviewDescription { get => _overviewDescription; private set => _overviewDescription = value; }
        public VisibilityEnum? Visibility { get => _visibility; private set => _visibility = value; }
        public ExperienceLevelEnum? ExperienceLevel { get => _experienceLevel; private set => _experienceLevel = value; }
        public VideoIntroduction? VideoIntroduction { get => _videoIntroduction; private set => _videoIntroduction = value; }
        public Availability? Availability { get => _availability; private set => _availability = value; }
        public List<Experience> Experiences => _experiences;
        public List<Education> Educations => _educations;
        public List<Portfolio> Portfolios => _portfolios;
        public List<FreelancerSkill> FreelancerSkills => _freelancerSkills;
        public List<Certification> Certifications => _certification;
        public List<EmploymentHistory> EmploymentHistory => _employmentHistory;
        public List<Category> Categories => _categories;

        #endregion

        #region public methods
        #region Basic Details
        public void UpdateTitle(string field)
        {
            _title = field;
        }
        public void UpdateHourlyRate(decimal field)
        {
            _hourlyRate = field;
        }

        public void UpdateAvailability(Availability availability)
        {
            _availability = availability;
        }
        public void UpdateOverviewDescription(string field)
        {
            _overviewDescription = field;
        }
        public void UpdateVideoIntroduction(VideoIntroduction videoIntroduction)
        {
            _videoIntroduction = videoIntroduction;
        }
        public void UpdateVisibility(VisibilityEnum field)
        {
            _visibility = field;
        }
        public void UpdateExperienceLevel(ExperienceLevelEnum field)
        {
            _experienceLevel = field;
        }
        #endregion



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


        #region Employment History
        public void AddEmploymentHistory(List<EmploymentHistory> data)
        {
            _employmentHistory.AddRange(data);
        }
        public void AddEmploymentHistory(EmploymentHistory data)
        {
            _employmentHistory.Add(data);
        }
        public void RemoveEmploymentHistory(Guid id)
        {
            var data = _employmentHistory.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.MarkAsDeleted(id);
        }
        public void UpdateEmploymentHistory(Guid id, EmploymentHistory employmentHistory)
        {
            var data = _employmentHistory.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.UpdateDescription(employmentHistory.Description);
            data.UpdateEndDate(employmentHistory.EndDate);
            data.UpdateStartDate(employmentHistory.StartDate);
            data.UpdateCompanyName(employmentHistory.CompanyName);
            data.UpdateTitle(employmentHistory.Title);
            data.UpdateLocation(employmentHistory.Location);
            data.UpdateIsCurrentlyWork(employmentHistory.IsCurrentlyWork);
        }
        #endregion

        #region Category
        public void AddCategory(List<Category> data)
        {
            _categories.AddRange(data);
        }
        public void AddCategory(Category data)
        {
            _categories.Add(data);
        }
        public void RemoveCategory(Guid id)
        {
            var data = _categories.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void UpdateCategory(Guid id, Category obj)
        {
            var data = _categories.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.UpdateDescription(obj.Description);
            data.UpdateName(obj.Name);
        }
        #endregion

        #region Experience
        public void AddEExperience(List<Experience> data)
        {
            _experiences.AddRange(data);
        }
        public void AddExperience(Experience data)
        {
            _experiences.Add(data);
        }
        public void RemoveExperience(Guid id)
        {
            var data = _experiences.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void UpdateExperience(Guid id, Experience obj)
        {
            var data = _experiences.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.UpdateDescription(obj.Description);
            data.UpdateSubject(obj.Subject);
        }
        #endregion        #region Experience


        #region Education
        public void AddEducation(List<Education> data)
        {
            _educations.AddRange(data);
        }
        public void AddEducation(Education data)
        {
            _educations.Add(data);
        }
        public void RemoveEducation(Guid id)
        {
            var data = _educations.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void UpdateEducation(Guid id, Education obj)
        {
            var data = _educations.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.UpdateDescription(obj.Description);
            data.UpdateSchool(obj.SchoolName);
            data.UpdateDegree(obj.Degree);
            data.UpdateYearAttended(obj.YearAttended);
            data.UpdateYearGraduated(obj.YearGraduated);
        }
        #endregion

        #region Portfolio
        public void AddPortfolio(Portfolio data, List<PortfolioSkill> portfolioSkills, List<PortfolioFile> portfolioFiles)
        {
            data.AddPortfolioFiles(portfolioFiles);
            data.AddPortfolioSkills(portfolioSkills);

            _portfolios.Add(data);
        }
        public void RemovePortfolio(Guid id)
        {
            var data = _portfolios.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void UpdatePortfolio(Guid id, Portfolio obj, List<PortfolioSkill> portfolioSkills, List<PortfolioFile> portfolioFiles)
        {
            var data = _portfolios.FirstOrDefault(x => x.Id == id);
            if (data is null) return;

            data.UpdateCompletionDate(obj.CompletionDate.Value);
            data.UpdateRelatedSpecializedProfile(obj.RelatedSpecializedProfile);
            data.UpdateFileCaption(obj.FileCaption);
            data.UpdateYouTubeLink(obj.YouTubeLink);
            data.UpdateProjectDescription(obj.ProjectDescription);
            data.UpdateProjectSolutionDescription(obj.ProjectSolutionDescription);
            data.UpdateProjectTaskDescription(obj.ProjectTaskDescription);
            data.UpdateRole(obj.Role);
            data.UpdateProjectURL(obj.ProjectURL);
            data.UpdateProjectTitle(obj.ProjectTitle);
            // list
            data.UpdatePortfolioSkills(portfolioSkills);
        }
        #endregion        
        #endregion
    }
}
