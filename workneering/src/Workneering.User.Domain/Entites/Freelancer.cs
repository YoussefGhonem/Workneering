using System.Linq;
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
        private VideoIntroduction? _videoIntroduction = new();
        private int? _availability;
        private readonly List<Education> _educations = new();
        private readonly List<Portfolio> _portfolios = new();
        private readonly List<EmploymentHistory> _employmentHistory = new();
        private readonly List<Experience> _experiences = new();
        private readonly FreelancerCategory _category = new();
        private readonly List<Language> _languages = new();
        private readonly List<Certification> _certifications = new();
        private List<UserCategory>? _categories = new();
        private List<UserSubCategory>? _subCategories = new();
        private List<UserSkill>? _skills = new();
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
        public ExperienceLevelEnum? ExperienceLevel { get => _experienceLevel; private set => _experienceLevel = value; }
        public VideoIntroduction? VideoIntroduction { get => _videoIntroduction; private set => _videoIntroduction = value; }
        public int? Availability { get => _availability; private set => _availability = value; }
        public List<Experience> Experiences => _experiences;
        public List<Education> Educations => _educations;
        public List<Portfolio> Portfolios => _portfolios;
        public List<UserCategory>? Categories => _categories;
        public List<UserSubCategory>? SubCategories => _subCategories;
        public List<UserSkill>? Skills => _skills;
        public List<Certification> Certifications => _certifications;
        public List<Language> Languages => _languages;
        public List<EmploymentHistory> EmploymentHistory => _employmentHistory;
        public FreelancerCategory Category => _category;

        #endregion

        #region public methods

        #region Basic Details
        public void UpdateReviews(decimal? field)
        {
            _numOfReviews++;
            var summ = _reviews + field;
            _reviews = summ / _numOfReviews;
        }
        public void UpdateIsMarked(bool field)
        {
            _isMarked = field;
        }
        public void UpdateYearsOfExperience(decimal? field)
        {
            _yearsOfExperience = field;
        }
        public void UpdateTitle(string? field)
        {
            _title = field;
        }
        public void UpdateTitleOverview(string? field)
        {
            _titleOverview = field;
        }
        public void UpdateGender(GenderEnum? field)
        {
            _gender = field;
        }
        public void UpdateHourlyRate(decimal? field)
        {
            _hourlyRate = field;
        }
        public void UpdateAvailability(int availability)
        {
            _availability = availability;
        }
        public void UpdateOverviewDescription(string? field)
        {
            _overviewDescription = field;
        }
        public void UpdateVideoIntroduction(VideoIntroduction videoIntroduction)
        {
            _videoIntroduction = videoIntroduction;
        }

        public void UpdateExperienceLevel(ExperienceLevelEnum? field)
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
            data.UpdateEndDate(employmentHistory.EndYear);
            data.UpdateStartDate(employmentHistory.StartYear);
            data.UpdateCompanyName(employmentHistory.CompanyName);
            data.UpdateTitle(employmentHistory.Title);
            data.UpdateRole(employmentHistory.Role);
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
            data.UpdateStartYear(employmentHistory.StartYear);
            data.UpdateEndYear(employmentHistory.EndYear);
            data.UpdatName(employmentHistory.Name);
            data.UpdateGivenBy(employmentHistory.GivenBy);
            data.UpdateAwardAreaOfStudy(employmentHistory.AwardAreaOfStudy);
        }
        #endregion

        #region Category
        public void UpdateCategory(Guid? categoryId)
        {
            _category.UpdateCategoryId(categoryId.Value);
        }
        #endregion


        #region Category
        public void UpdateCategory(List<Guid>? categoryIds)
        {
            var ids = _categories.Select(x => x.CategoryId).ToList();
            if (!ids.Any()) return;

            var addNewItems = categoryIds?.Except(ids);
            var removeItems = ids?.Except(categoryIds);
            var result = addNewItems.Select(x => new UserCategory(x));
            _categories.AddRange(result);

            foreach (var item in removeItems)
            {
                var data = _categories.FirstOrDefault(x => x.CategoryId == item);
                data.MarkAsDeleted(null);
            }

        }
        public void UpdateSubCategory(List<Guid>? externalIds)
        {
            var ids = _subCategories?.Select(x => x.SubCategoryId).ToList();
            if (!ids.Any()) return;

            var addNewItems = externalIds?.Except(ids);
            var removeItems = ids?.Except(externalIds);
            var result = addNewItems.Select(x => new UserSubCategory(x));
            _subCategories.AddRange(result);

            foreach (var item in removeItems)
            {
                var data = _subCategories.FirstOrDefault(x => x.SubCategoryId == item);
                data.MarkAsDeleted(null);
            }

        }
        public void UpdateSkills(List<Guid> externalIds)
        {
            var ids = _skills.Select(x => x.SkillId).ToList();
            if (!ids.Any()) return;

            var addNewItems = externalIds.Except(ids);
            var removeItems = ids.Except(externalIds);
            var result = addNewItems.Select(x => new UserSkill(x));
            _skills.AddRange(result);

            foreach (var item in removeItems)
            {
                var data = _skills.FirstOrDefault(x => x.SkillId == item);
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
        public void UpdateLanguage(Guid id, Language language)
        {
            var data = _languages.FirstOrDefault(x => x.Id == id);
            data.UpdateLanguageId(language.LanguageId);
            data.UpdateLevel(language.Level);
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
        public void AddPortfolio(Portfolio data)
        {
            _portfolios.Add(data);
        }
        public void RemovePortfolio(Guid id)
        {
            var data = _portfolios.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void UpdatePortfolio(Guid? id, Portfolio obj)
        {
            var data = _portfolios.FirstOrDefault(x => x.Id == id);
            if (data is null) return;

            data.UpdateProjectDescription(obj.ProjectDescription);
            data.UpdateStartYear(obj.StartYear);
            data.UpdateEndYear(obj.EndYear);
            data.UpdateProjectTitle(obj.ProjectTitle);
            // list
        }
        #endregion        

        #endregion
    }
}
