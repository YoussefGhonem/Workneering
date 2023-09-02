using Workneering.Base.Domain.Common;
using Workneering.Base.Helpers.Enums;
using Workneering.User.Domain.Enums;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Entites
{
    public record Freelancer : BaseEntity
    {
        private bool _isMarked;
        private string? _titleOverview;
        private string _name;
        private GenderEnum? _gender;
        private decimal? _yearsOfExperience;
        private decimal? _reviews; // 4.3 of 5 stars
        private int? _numOfReviews; // 100 clients for example
        private decimal? _hourlyRate;
        private string? _title;
        private string? _overviewDescription;
        private ExperienceLevelEnum? _experienceLevel;
        private VisibilityEnum? _visibility;
        private VideoIntroduction? _videoIntroduction = new();
        private Availability? _availability = new();
        private readonly List<Education> _educations = new();
        private readonly List<Portfolio> _portfolios = new();
        private readonly List<EmploymentHistory> _employmentHistory = new();
        private readonly List<Experience> _experiences = new();
        private readonly List<Category> _categories = new();
        private readonly List<FreelancerSkill> _freelancerSkills = new();
        private readonly List<Language> _languages = new();
        private readonly List<Certification> _certifications = new();
        private readonly List<Testimonial> _testimonials = new();
        public Freelancer()
        {

        }
        public Freelancer(Guid id, string name)
        {
            Id = id;
            _name = name;
        }

        #region public fields
        public bool IsMarked { get => _isMarked; private set => _isMarked = value; }
        public string? TitleOverview { get => _titleOverview; private set => _titleOverview = value; }
        public string? Name { get => _name; private set => _name = value; }
        public GenderEnum? Gender { get => _gender; private set => _gender = value; }
        public decimal? Reviews { get => _reviews; private set => _reviews = value; }
        public int? NumOfReviews { get => _numOfReviews; private set => _numOfReviews = value; }
        public decimal? YearsOfExperience { get => _yearsOfExperience; private set => _yearsOfExperience = value; }
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
        public List<Certification> Certifications => _certifications;
        public List<Language> Languages => _languages;
        public List<EmploymentHistory> EmploymentHistory => _employmentHistory;
        public List<Category> Categories => _categories;
        public List<Testimonial> Testimonials => _testimonials;

        #endregion

        #region public methods
        #region Basic Details
        public void UpdateReviews(decimal field)
        {
            _numOfReviews++;
            var summ = _reviews + field;
            _reviews = summ / _numOfReviews;
        }
        public void UpdateIsMarked(bool field)
        {
            _isMarked = field;
        }
        public void UpdateYearsOfExperience(decimal field)
        {
            _yearsOfExperience = field;
        }
        public void UpdateTitle(string field)
        {
            _title = field;
        }
        public void UpdateTitleOverview(string field)
        {
            _titleOverview = field;
        }
        public void UpdateGender(GenderEnum? field)
        {
            _gender = field;
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

        #region Certification
        public void AddCertification(Certification data)
        {
            _certifications.Add(data);
        }
        public void RemoveCertification(Guid id)
        {
            var data = _certifications.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.MarkAsDeleted(id);
        }
        public void UpdateCertification(Guid id, Certification employmentHistory)
        {
            var data = _certifications.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.UpdateDescription(employmentHistory.Description);
            data.UpdatePassedDate(employmentHistory.PassedDate);
            data.UpdatName(employmentHistory.Name);
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

        #region Testimonial

        public void AddTestimonial(Testimonial data)
        {
            _testimonials.Add(data);
        }
        public void RemoveTestimonial(Guid id)
        {
            var data = _testimonials.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void UpdateTestimonial(Guid id, Testimonial obj)
        {
            var data = _testimonials.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.UpdateBusinessEmail(obj.BusinessEmail);
            data.UpdateClientTitle(obj.ClientTitle);
            data.UpdateLastName(obj.LastName);
            data.UpdateLinkedInProfile(obj.LinkedInProfile);
            data.UpdateMessageToClient(obj.MessageToClient);
            data.UpdateProjectType(obj.ProjectType);
        }
        public void UpdateTestimonialReplyClient(Guid id, string message)
        {
            var data = _testimonials.FirstOrDefault(x => x.Id == id);
            if (data is null) return;
            data.UpdateReplayClient(message);

        }
        #endregion

        #region Freelancer Skills
        public void UpdateFreelancerSkills(List<FreelancerSkill>? freelancerSkills)
        {
            var addNewItems = freelancerSkills?.Where(x => x.Id == null);
            var removeItems = _freelancerSkills.Select(x => x.Id).Except(freelancerSkills.Select(x => x.Id));
            var removItemsObj = _freelancerSkills.Where(x => removeItems.Contains(x.Id));
            var newItemsObj = _freelancerSkills.Where(x => removeItems.Contains(x.Id));
            _freelancerSkills.AddRange(addNewItems);

            foreach (var item in removItemsObj)
            {
                var data = _freelancerSkills.FirstOrDefault(x => x.Id == item.Id);
                data.MarkAsDeleted(null);
            }
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

        #region Language

        public void AddLanguage(Language data)
        {
            _languages.Add(data);
        }
        public void RemoveLanguage(Guid id)
        {
            var data = _languages.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void RemoveLanguages(List<Guid>? ids)
        {
            var removItemsObj = _languages.Where(x => ids.Contains(x.Id));
            foreach (var item in removItemsObj)
            {
                RemoveLanguage(item.Id);
            }
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
