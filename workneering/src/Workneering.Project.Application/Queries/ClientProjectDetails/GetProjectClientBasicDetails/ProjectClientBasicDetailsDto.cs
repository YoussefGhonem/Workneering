using Workneering.Project.Application.Services.Models;
using Workneering.Project.Domain.Entities;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectClientBasicDetails;
public class ProjectClientBasicDetailsDto
{
    public Guid ClientId { get; set; }
    public string? ProjectTitle { get; set; }
    public string? ProjectDescription { get; set; }
    public bool? IsOpenDueDate { get; set; }
    public string? DueDate { get; set; }
    public decimal? ProjectBudgetPrice { get; set; }
    public ProjectTypeEnum? ProjectType { get; set; }
    public ProjectStatusEnum? ProjectStatus { get; set; }
    public ExperienceLevelEnum? ExperienceLevel { get; set; }
    public ProjectBudgetEnum? ProjectBudget { get; set; }
    public List<CategoriesDto>? Categories { get; set; } = new();
    public List<SubCategoriesDto>? SubCategories { get; set; } = new();
    public List<SkillsDto>? Skills { get; set; } = new();
    public List<ProposalsDto> Proposals { get; set; } = new();
    public List<SubmittedOffersDto> SubmittedOffers { get; set; } = new();
}

public class CategoriesDto
{
    public Guid? CategoryId { get; set; }
    public string? Name { get; set; } = null;
}
public class SubCategoriesDto
{
    public Guid? SubCategoryId { get; set; }
    public string? Name { get; set; } = null;
}
public class SkillsDto
{
    public Guid? SkillId { get; set; }
    public string? Name { get; set; } = null;
}
public class SubmittedOffersDto
{
    public Guid? FreelancerId { get; set; }
    public string? Name { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? CountryName { get; set; } = null;
}
public class ProposalsDto
{
    public SubmittedOffersDto FreelancerDetails { get; set; } = new();
    public string? CoverLetter { get; set; }
    public Guid? FreelancerId { get; set; }
    public decimal? HourlyRate { get; set; }
    public decimal? TotalBid { get; set; }
    public ProposalDurationEnum? ProposalDuration { get; set; }
    public ProposalStatusEnum? ProposalStatus { get; set; }
}
