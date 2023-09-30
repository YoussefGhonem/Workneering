using Workneering.Base.Domain.Common;
using Workneering.Base.Helpers.Extensions;
using Workneering.Project.Domain.Enums;
using Workneering.Shared.Core.Models;

namespace Workneering.Project.Domain.Entities
{
    public record Project : BaseEntity
    {
        private bool? _isRecommend;
        private string? _projectTitle;
        private string? _projectDescription;
        private bool? _isOpenDueDate;
        private decimal? _projectFixedBudgetPrice;
        private decimal? _projectHourlyFromPrice;
        private decimal? _projectHourlyToPrice;
        private Guid? _clientId;
        private Guid? _assginedFreelancerId;
        private string? _projectDurationDescription;
        private ProjectDurationEnum? _projectDuration;
        private HoursPerWeekEnum? _hoursPerWeek;
        private ProjectStatusEnum? _projectStatus;
        private ExperienceLevelEnum? _experienceLevel;
        private ProjectBudgetEnum? _projectBudget;
        private ProjectTypeEnum? _projectType;
        private List<Wishlist> _wishlist = new();
        private List<ProjectActivity> _activities = new();
        private List<Proposal> _proposals = new();
        private List<ProjectCategory>? _categories = new();
        private List<ProjectSkill>? _skills = new();
        private List<ProjectSubCategory>? _subCategories = new();
        private List<ProjectAttachment>? _attachments = new();



        public Project(
             List<ProjectAttachment>? attachments,
             List<ProjectSubCategory>? subCategories,
             List<ProjectCategory>? categories,
             List<ProjectSkill>? skills,
            HoursPerWeekEnum? hoursPerWeek, ProjectDurationEnum? projectDuration, ProjectTypeEnum? projectType, string? projectTitle, string? projectDescription = null, bool? isOpenDueDate = null,
            string? projectDurationDescription = null, decimal? projectBudgetPrice = null,
            Guid? clientId = null, ProjectStatusEnum? projectStatus = null, ExperienceLevelEnum? experienceLevel = null,
            ProjectBudgetEnum? projectBudget = null, decimal? projectHourlyFromPrice = null, decimal? projectHourlyToPrice = null, bool? isRecommend = null)
        {
            _projectTitle = projectTitle;
            _attachments = attachments;
            _projectDescription = projectDescription;
            _isOpenDueDate = isOpenDueDate;
            _projectDurationDescription = projectDurationDescription;
            _projectFixedBudgetPrice = projectBudgetPrice;
            _clientId = clientId;
            _projectStatus = projectStatus;
            _experienceLevel = experienceLevel;
            _projectBudget = projectBudget;
            _projectDuration = projectDuration;
            _projectType = projectType;
            _hoursPerWeek = hoursPerWeek;
            _subCategories.AddRange(subCategories);
            _categories.AddRange(categories);
            _skills.AddRange(skills);
            _activities.Add(new ProjectActivity(@$"Created Project 🎉'{projectTitle}'", @$"The Project Created on '{CreatedDate.FormatDateTimeOffset()}'"));
            _projectHourlyFromPrice = projectHourlyFromPrice;
            _projectHourlyToPrice = projectHourlyToPrice;
            _isRecommend = isRecommend;
        }
        private void AddCategorization()
        {

        }

        public Project()
        {

        }
        #region Public Fields
        public string? ProjectTitle { get => _projectTitle; private set => _projectTitle = value; }
        public string? ProjectDescription { get => _projectDescription; private set => _projectDescription = value; }
        public bool? IsOpenDueDate { get => _isOpenDueDate; private set => _isOpenDueDate = value; }
        public string? ProjectDurationDescription { get => _projectDurationDescription; private set => _projectDurationDescription = value; }
        public decimal? ProjectFixedBudgetPrice { get => _projectFixedBudgetPrice; private set => _projectFixedBudgetPrice = value; }
        public Guid? ClientId { get => _clientId; private set => _clientId = value; }
        public Guid? AssginedFreelancerId { get => _assginedFreelancerId; private set => _assginedFreelancerId = value; }
        public ProjectDurationEnum? ProjectDuration { get => _projectDuration; private set => _projectDuration = value; }
        public ProjectStatusEnum? ProjectStatus { get => _projectStatus; private set => _projectStatus = value; }
        public ExperienceLevelEnum? ExperienceLevel { get => _experienceLevel; private set => _experienceLevel = value; }
        public ProjectBudgetEnum? ProjectBudget { get => _projectBudget; private set => _projectBudget = value; }
        public HoursPerWeekEnum? HoursPerWeek { get => _hoursPerWeek; private set => _hoursPerWeek = value; }
        public ProjectTypeEnum? ProjectType { get => _projectType; private set => _projectType = value; }
        public decimal? ProjectHourlyToPrice { get => _projectHourlyToPrice; private set => _projectHourlyToPrice = value; }
        public decimal? ProjectHourlyFromPrice { get => _projectHourlyFromPrice; private set => _projectHourlyFromPrice = value; }
        public bool? IsRecommend { get => _isRecommend; private set => _isRecommend = value; }

        public List<ProjectActivity> Activities => _activities;
        public List<Proposal> Proposals => _proposals;
        public List<Wishlist> Wishlist => _wishlist;

        public List<ProjectCategory>? Categories => _categories;
        public List<ProjectSubCategory>? SubCategories => _subCategories;
        public List<ProjectSkill>? Skills => _skills;
        public List<ProjectAttachment>? Attachments => _attachments;


        #endregion

        #region Public Methods

        #region Basic Details
        public void UpdateHourlyFromPrice(decimal? field)
        {
            _projectHourlyFromPrice = field;

        }
        public void SetAssginedFreelancerId(Guid? field)
        {
            _assginedFreelancerId = field;
            _activities.Add(new ProjectActivity(@$"Accepted Freelancer 👏", @$"You assgined this project to freelancer", "color1"));

        }
        public void UpdateIsRecommend(bool? field)
        {
            _isRecommend = field;

        }
        public void UpdateHourlyToPrice(decimal? field)
        {
            _projectHourlyToPrice = field;

        }
        public void UpdateProjectTitle(string field)
        {
            _projectTitle = field;

        }
        public void UpdateProjectDescription(string? field)
        {
            _projectDescription = field;
        }
        public void UpdateHoursPerWeek(HoursPerWeekEnum? field)
        {
            _hoursPerWeek = field;
        }
        public void UpdateIsOpenDueDate(bool? field)
        {
            _isOpenDueDate = field;
        }
        public void UpdateProjectDurationDescription(string? field)
        {

            _projectDurationDescription = field;
        }
        public void UpdateProjectDuration(ProjectDurationEnum? field)
        {

            _projectDuration = field;
        }
        public void UpdateProjectBudgetPrice(decimal? field)
        {
            _projectFixedBudgetPrice = field;
        }

        public void UpdateProjectStatus(ProjectStatusEnum? field)
        {
            _activities.Add(new ProjectActivity($@"Project Status Changed ✔ ", @$"project status converted into '{field.ToString()}'", "color4"));

            _projectStatus = field;
        }
        public void UpdateExperienceLevel(ExperienceLevelEnum? field)
        {
            _experienceLevel = field;
        }
        public void UpdateProjectBudget(ProjectBudgetEnum? field)
        {
            _projectBudget = field;
        }
        public void UpdateProjectType(ProjectTypeEnum? field)
        {
            _projectType = field;
        }
        #endregion


        #region categorization
        public void UpdateCategory(List<ProjectCategory>? categories)
        {
            var idsExternal = categories.Select(x => x.CategoryId).ToList();
            var idsDatabase = _categories.Select(x => x.CategoryId).ToList();
            if (!idsDatabase.Any()) return;

            var addNewItemsIds = idsExternal.Except(idsDatabase);
            var newItems = categories.Where(x => addNewItemsIds.Contains(x.CategoryId));
            var result = newItems.Select(x => new ProjectCategory(x.CategoryId, x.Name));
            _categories.AddRange(result);


            var removeItemsIds = idsDatabase.Except(idsExternal);
            var removeItems = categories.Where(x => removeItemsIds.Contains(x.CategoryId));
            foreach (var item in removeItems)
            {
                var data = _categories.FirstOrDefault(x => x.CategoryId == item.CategoryId);
                data.MarkAsDeleted(null);
            }
        }
        public void UpdateSubCategory(List<ProjectSubCategory>? categories)
        {
            var idsExternal = categories.Select(x => x.SubCategoryId).ToList();
            var idsDatabase = _subCategories.Select(x => x.SubCategoryId).ToList();
            if (!idsDatabase.Any()) return;

            var addNewItemsIds = idsExternal.Except(idsDatabase);
            var newItems = categories.Where(x => addNewItemsIds.Contains(x.SubCategoryId));
            var result = newItems.Select(x => new ProjectSubCategory(x.SubCategoryId, x.Name));
            _subCategories.AddRange(result);


            var removeItemsIds = idsDatabase.Except(idsExternal);
            var removeItems = categories.Where(x => removeItemsIds.Contains(x.SubCategoryId));
            foreach (var item in removeItems)
            {
                var data = _subCategories.FirstOrDefault(x => x.SubCategoryId == item.SubCategoryId);
                data.MarkAsDeleted(null);
            }
        }
        public void UpdateSkills(List<ProjectSkill>? categories)
        {
            var idsExternal = categories.Select(x => x.SkillId).ToList();
            var idsDatabase = _skills.Select(x => x.SkillId).ToList();
            if (!idsDatabase.Any()) return;

            var addNewItemsIds = idsExternal.Except(idsDatabase);
            var newItems = categories.Where(x => addNewItemsIds.Contains(x.SkillId));
            var result = newItems.Select(x => new ProjectSkill(x.SkillId, x.Name));
            _skills.AddRange(result);


            var removeItemsIds = idsDatabase.Except(idsExternal);
            var removeItems = categories.Where(x => removeItemsIds.Contains(x.SkillId));
            foreach (var item in removeItems)
            {
                var data = _skills.FirstOrDefault(x => x.SkillId == item.SkillId);
                data.MarkAsDeleted(null);
            }
        }

        #endregion

        #region Wishlist
        public void AddIntoWishlist(Guid? freelancerId)
        {
            _wishlist.Add(new Wishlist(freelancerId));
        }
        public void RemoveFromWishlist(Guid? freelancerId)
        {
            if (freelancerId == null) return;
            _wishlist.FirstOrDefault(x => x.FreelancerId == freelancerId)?.MarkAsDeleted(null);
        }
        #endregion    

        #region Attachment
        public void AddAttachment(FileDto? field)
        {

            _attachments.Add(new ProjectAttachment(field));

            if (ProjectStatus == ProjectStatusEnum.Active)
            {
                _activities.Add(new ProjectActivity($@"Add new Attachment 📎 ", @$"You provide a new atachment in this project: '{field.FileName}'", "color5"));

            }
        }
        public void RemoveAttachment(string? key)
        {
            var obj = _attachments.FirstOrDefault(x => x.ImageDetails.Key == key);
            _attachments.Remove(obj);
            if (ProjectStatus == ProjectStatusEnum.Active)
            {
                _activities.Add(new ProjectActivity($@"Remove Attachment ❌", @$"You removed an atachment from this project: '{obj.ImageDetails.FileName}'", "color3"));

            }
        }
        #endregion

        #region Proposal
        public void AddProposal(Guid? freelancerId, string? coverLetter, ProposalDurationEnum? proposalDuratio,
            decimal? totalBid, decimal? hourlyRate)
        {
            var proposalStatus = ProposalStatusEnum.Submitted;
            _proposals.Add(new Proposal(freelancerId, coverLetter, proposalDuratio, totalBid, hourlyRate));
        }
        public void AcceptProposal(Guid proposalId)
        {
            var proposalStatus = ProposalStatusEnum.Accepted;
            var porposal = _proposals.FirstOrDefault(x => x.Id == proposalId);
            porposal.UpdateProposalStatus(proposalStatus);
            UpdateProjectStatus(ProjectStatusEnum.Active);
            var otherPorposals = _proposals.Where(x => x.Id != proposalId);
            foreach (var item in otherPorposals)
            {
                if (item.ProposalStatus != ProposalStatusEnum.Rejected)
                {
                    item.UpdateProposalStatus(ProposalStatusEnum.Achieved);
                }
            }

            _activities.Add(new ProjectActivity($@"Accept Proposal ✔", @$"Greate 🎉 you accepted proposal from freelancer", "color6"));
        }
        public void RejectedProposal(Guid proposalId)
        {
            var proposalStatus = ProposalStatusEnum.Rejected;
            var porposal = _proposals.FirstOrDefault(x => x.Id == proposalId);
            porposal.UpdateProposalStatus(proposalStatus);

        }
        #endregion
        #endregion
    }
}
