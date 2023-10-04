using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectClientBasicDetails;
public class ProjectClientBasicDetailsDto
{
    public Guid ClientId { get; set; }
    public string? ProjectTitle { get; set; }
    public Guid? AssginedFreelancerId { get; set; }
    public string? ProjectDescription { get; set; }
    public bool? IsOpenDueDate { get; set; }
    public string? DueDate { get; set; }
    public decimal? ProjectFixedBudgetPrice { get; set; }
    public decimal? ProjectHourlyToPrice { get; set; }
    public int? NumberOfProposals { get; set; }
    public DateTimeOffset? CreatedDate { get; set; }
    public decimal? ProjectHourlyFromPrice { get; set; }
    public string? ProjectType { get; set; }
    public string? HoursPerWeek { get; set; }
    public ProjectStatusEnum? ProjectStatus { get; set; }
    public string? ExperienceLevel { get; set; }
    public ProjectBudgetEnum? ProjectBudget { get; set; }
    public List<CategoriesDto>? Categories { get; set; } = new();
    public List<SubCategoriesDto>? SubCategories { get; set; } = new();
    public List<SkillsDto>? Skills { get; set; } = new();
    public List<SubmittedOffersDto> SubmittedOffers { get; set; } = new();
    public ClientInfoDto ClientInfo { get; set; } = new();
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
    public string? ImageUrl { get; set; } = null;
}
public class ClientInfoDto
{
    public string? Name { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? CountryName { get; set; } = null;
    public string? ImageUrl { get; set; } = null;
}
public class ClientProposalsDto
{
    public SubmittedOffersDto FreelancerDetails { get; set; } = new();
    public string? CoverLetter { get; set; }
    public Guid? FreelancerId { get; set; }
    public DateTimeOffset? CreatedDate { get; set; }

    public decimal? TotalBid { get; set; }
    public ProposalDurationEnum? ProposalDuration { get; set; }
    public ProposalStatusEnum? ProposalStatus { get; set; }
}
