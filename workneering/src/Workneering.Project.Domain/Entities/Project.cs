﻿using Workneering.Base.Domain.Common;
using Workneering.Project.Domain.Enums;
using Workneering.Project.Domain.ValueObject;

namespace Workneering.Project.Domain.Entities
{
    public record Project : BaseEntity
    {
        private string? _projectTitle;
        private string? _projectDescription;
        private bool? _isOpenDueDate;
        private decimal? _projectBudgetPrice;
        private ProjectCategory? _projectCategory;
        private Guid? _clientId;
        private string? _projectDurationDescription;
        private ProjectDurationEnum? _projectDuration;
        private HoursPerWeekEnum? _hoursPerWeek;
        private ProjectStatusEnum? _projectStatus;
        private ExperienceLevelEnum? _experienceLevel;
        private ProjectBudgetEnum? _projectBudget;
        private ProjectTypeEnum? _projectType;
        private List<ProjectSkill> _requiredSkills = new();
        private List<Wishlist> _wishlist = new();
        private List<ProjectActivity> _activities = new();
        private List<Proposal> _proposals = new();


        public Project(HoursPerWeekEnum? hoursPerWeekEnum, ProjectDurationEnum? projectDuration, string? projectTitle, string? projectDescription = null, bool? isOpenDueDate = null,
            string? projectDurationDescription = null, decimal? projectBudgetPrice = null, ProjectCategory? projectCategory = null,
            Guid? clientId = null, ProjectStatusEnum? projectStatus = null, ExperienceLevelEnum? experienceLevel = null,
            ProjectBudgetEnum? projectBudget = null, List<ProjectSkill> requiredSkills = null)
        {
            _projectTitle = projectTitle;
            _projectDescription = projectDescription;
            _isOpenDueDate = isOpenDueDate;
            _projectDurationDescription = projectDurationDescription;
            _projectBudgetPrice = projectBudgetPrice;
            _projectCategory = projectCategory;
            _clientId = clientId;
            _projectStatus = projectStatus;
            _experienceLevel = experienceLevel;
            _projectBudget = projectBudget;
            _requiredSkills = requiredSkills;
            _projectDuration = projectDuration;
            _projectBudgetPrice = projectBudgetPrice;
            _activities.Add(new ProjectActivity(@$"You Created Project '{projectTitle}'"));
        }
        public Project()
        {

        }
        #region Public Fields
        public string? ProjectTitle { get => _projectTitle; private set => _projectTitle = value; }
        public string? ProjectDescription { get => _projectDescription; private set => _projectDescription = value; }
        public bool? IsOpenDueDate { get => _isOpenDueDate; private set => _isOpenDueDate = value; }
        public string? ProjectDurationDescription { get => _projectDurationDescription; private set => _projectDurationDescription = value; }
        public decimal? ProjectBudgetPrice { get => _projectBudgetPrice; private set => _projectBudgetPrice = value; }
        public ProjectCategory? ProjectCategory { get => _projectCategory; private set => _projectCategory = value; }
        public Guid? ClientId { get => _clientId; private set => _clientId = value; }
        public ProjectDurationEnum? ProjectDuration { get => _projectDuration; private set => _projectDuration = value; }
        public ProjectStatusEnum? ProjectStatus { get => _projectStatus; private set => _projectStatus = value; }
        public ExperienceLevelEnum? ExperienceLevel { get => _experienceLevel; private set => _experienceLevel = value; }
        public ProjectBudgetEnum? ProjectBudget { get => _projectBudget; private set => _projectBudget = value; }
        public HoursPerWeekEnum? HoursPerWeek { get => _hoursPerWeek; private set => _hoursPerWeek = value; }
        public ProjectTypeEnum? ProjectType { get => _projectType; private set => _projectType = value; }
        public List<ProjectSkill> RequiredSkills => _requiredSkills;
        public List<ProjectActivity> Activities => _activities;
        public List<Proposal> Proposals => _proposals;
        public List<Wishlist> Wishlist => _wishlist;



        #endregion

        #region Public Methods
        #region Basic Details
        public void UpdateProjectTitle(string field)
        {
            _activities.Add(new ProjectActivity(@$"You Update Project Title From '{_projectTitle}' To '{field}'"));
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
            _activities.Add(new ProjectActivity(@$"You change Project duration description To '{field}'"));

            _projectDurationDescription = field;
        }
        public void UpdateProjectDuration(ProjectDurationEnum? field)
        {
            _activities.Add(new ProjectActivity(@$"You change project duration To '{field}'"));

            _projectDuration = field;
        }
        public void UpdateProjectBudgetPrice(decimal? field)
        {
            _projectBudgetPrice = field;
        }
        public void UpdateProjectCategory(ProjectCategory? field)
        {
            _activities.Add(new ProjectActivity(@$"You change category of project To '{field}'"));

            _projectCategory = field;
        }
        public void UpdateProjectStatus(ProjectStatusEnum? field)
        {
            _activities.Add(new ProjectActivity(@$"You project sttatus  To '{field.ToString()}'"));

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

        #region Project Skill
        public void UpdateFreelancerSkills(List<ProjectSkill>? freelancerSkills)
        {
            var addNewItems = freelancerSkills?.Where(x => x.SkillId == null);
            var removeItems = _requiredSkills.Select(x => x.SkillId).Except(freelancerSkills.Select(x => x.SkillId));
            var removItemsObj = _requiredSkills.Where(x => removeItems.Contains(x.SkillId));
            var newItemsObj = _requiredSkills.Where(x => removeItems.Contains(x.SkillId));

            foreach (var item in addNewItems)
            {
                _requiredSkills.Add(new ProjectSkill(item.Name, null));
            }

            foreach (var item in removItemsObj)
            {
                var data = _requiredSkills.FirstOrDefault(x => x.SkillId == item.SkillId);
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

        #region Proposal
        public void AddProposal(Guid? freelancerId, string? coverLetter, ProposalDurationEnum? proposalDuratio,
            decimal? totalBid, decimal? hourlyRate)
        {
            var proposalStatus = ProposalStatusEnum.Submitted;
            _proposals.Add(new Proposal(proposalStatus, freelancerId, coverLetter, proposalDuratio, totalBid, hourlyRate));
        }
        public void AcceptProposal(Guid proposalId)
        {
            var proposalStatus = ProposalStatusEnum.Accepted;
            var porposal = _proposals.FirstOrDefault(x => x.Id == proposalId);
            porposal.UpdateProposalStatus(proposalStatus);

            var otherPorposals = _proposals.Where(x => x.Id != proposalId);
            foreach (var item in otherPorposals)
            {
                if (item.ProposalStatus != ProposalStatusEnum.Rejected)
                {
                    item.UpdateProposalStatus(ProposalStatusEnum.None);
                }
            }
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
