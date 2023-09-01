using Workneering.Base.Domain.Common;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Domain.Entites
{
    public record Portfolio : BaseEntity
    {
        #region Private Fields
        // Basic Info Portfolio 
        private string _projectTitle;
        private SpecialtyEnum _relatedSpecializedProfile;
        private DateTimeOffset? _completionDate;
        private TemplateEnum _template;

        // template gallary
        private string? _projectURL;
        private string? _projectDescription;
        private string? _youTubeLink;
        private string? _fileCaption;
        private List<PortfolioSkill> _portfolioSkills = new();
        private List<PortfolioFile> _portfolioFiles = new();

        // template case study
        private string? _role;
        private string? _projectTaskDescription;
        private string? _projectSolutionDescription;
        #endregion
        public Portfolio()
        {

        }
        public Portfolio(TemplateEnum templateEnum, string projectTitle, SpecialtyEnum relatedSpecializedProfile)
        {
            _template = templateEnum;
            _projectTitle = projectTitle;
            _relatedSpecializedProfile = relatedSpecializedProfile;
        }

        #region public fields
        public virtual List<PortfolioSkill> PortfolioSkills => _portfolioSkills;
        public virtual List<PortfolioFile> PortfolioFiles => _portfolioFiles;
        public string ProjectTitle { get => _projectTitle; private set => _projectTitle = value; }
        public string ProjectURL { get => _projectURL; private set => _projectURL = value; }
        public string Role { get => _role; private set => _role = value; }
        public string? ProjectTaskDescription { get => _projectTaskDescription; private set => _projectTaskDescription = value; }
        public string? ProjectSolutionDescription { get => _projectSolutionDescription; private set => _projectSolutionDescription = value; }
        public string? ProjectDescription { get => _projectDescription; private set => _projectDescription = value; }
        public string? YouTubeLink { get => _youTubeLink; private set => _youTubeLink = value; }
        public string? FileCaption { get => _fileCaption; private set => _fileCaption = value; }
        public SpecialtyEnum RelatedSpecializedProfile { get => _relatedSpecializedProfile; private set => _relatedSpecializedProfile = value; }
        public DateTimeOffset? CompletionDate { get => _completionDate; private set => _completionDate = value; }
        public TemplateEnum Template { get => _template; private set => _template = value; }
        #endregion

        #region public methods
        public void AddPortfolioSkills(List<PortfolioSkill> portfolioSkills)
        {
            _portfolioSkills.AddRange(portfolioSkills);
        }
        public void AddPortfolioFiles(List<PortfolioFile> portfolioSkills)
        {
            _portfolioFiles.AddRange(portfolioSkills);
        }
        public void RemovePortfolioFile(Guid id)
        {
            var obj = _portfolioFiles.FirstOrDefault(x => x.Id == id);
            obj.MarkAsDeleted(id);
        }
        public void RemovePortfolioSkill(Guid id)
        {
            var obj = _portfolioSkills.FirstOrDefault(x => x.Id == id);
            obj.MarkAsDeleted(id);
        }
        public void UpdateProjectTitle(string field)
        {
            _projectTitle = field;
        }
        public void UpdateProjectURL(string field)
        {
            _projectURL = field;
        }
        public void UpdateRrole(string field)
        {
            _role = field;
        }
        public void UpdateProjectTaskDescription(string field)
        {
            _projectTaskDescription = field;
        }
        public void UpdateProjectSolutionDescription(string field)
        {
            _projectSolutionDescription = field;
        }
        public void UpdateProjectDescription(string field)
        {
            _projectDescription = field;
        }
        public void UpdateYouTubeLink(string field)
        {
            _youTubeLink = field;
        }
        public void UpdateFileCaption(string field)
        {
            _fileCaption = field;
        }
        public void UpdateRelatedSpecializedProfile(SpecialtyEnum field)
        {
            _relatedSpecializedProfile = field;
        }
        public void UpdateCompletionDate(DateTimeOffset field)
        {
            _completionDate = field;
        }
        public void UpdateCompletionDate(TemplateEnum field)
        {
            _template = field;
        }
        #endregion
    }
}
