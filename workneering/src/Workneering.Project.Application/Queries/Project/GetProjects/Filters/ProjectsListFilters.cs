using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.Project.GetProjects.Filters;
public class ProjectsListFilters : BaseFilterDto
{
    public bool IsWishlist { get; set; } = false;
    public Guid? ClientId { get; set; }
    public string? SearchWord { get; set; }
    public SortedByEnum? SortedBy { get; set; }
    public ProjectTypeEnum? ProjectType { get; set; }
    public ProjectBudgetEnum? ProjectBudget { get; set; }
    public ClientInfoEnum? ClientInfo { get; set; }
    public HoursPerWeekEnum? HoursPerWeek { get; set; }
    public List<Guid>? CountriesId { get; set; }
    public List<Guid>? CategoryIds { get; set; }
    public NumberOfProposalsDto? NumberOfProposals { get; set; }

}
public class NumberOfProposalsDto
{
    public int From { get; set; } = 0;
    public int To { get; set; } = 0;
}
public enum SortedByEnum
{
    Relevance = 1,
    Newest = 2,
    CleintRating = 3,
}
public enum ClientInfoEnum
{
    previousClients = 1,
    PaymentVerified = 2
}

