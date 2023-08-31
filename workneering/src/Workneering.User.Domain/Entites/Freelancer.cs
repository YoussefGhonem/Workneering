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
        private List<Education> _educations = new();
        private List<Portfolio> _portfolios = new();
        private List<FreelancerSkill> _skills = new();
        private List<Certification> _certification = new();
        private List<EmploymentHistory> _employmentHistory = new();
        private List<Experience> _experiences = new();
        private List<Category> _categories = new();
        public Freelancer(Guid id)
        {
            Id = id;
        }
    }
}
