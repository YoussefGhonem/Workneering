﻿using Workneering.Base.Domain.Common;
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
        private VideoIntroduction? _videoIntroduction;
        private Availability? _availability;
        private readonly List<Education> _educations = new();
        private readonly List<Portfolio> _portfolios = new();
        private readonly List<FreelancerSkill> _freelancerSkills = new();
        private readonly List<Certification> _certification = new();
        private readonly List<EmploymentHistory> _employmentHistory = new();
        private readonly List<Experience> _experiences = new();
        private readonly List<Category> _categories = new();
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
        #endregion


        #endregion
    }
}
