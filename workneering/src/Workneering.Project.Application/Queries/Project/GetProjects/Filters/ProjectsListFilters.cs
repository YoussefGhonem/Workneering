using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.Project.GetProjects.Filters;
public class ProjectsListFilters : BaseFilterDto
{
    public bool IsWishlist { get; set; } = false;
    public bool IsFreelancer { get; set; } = false;
    public string? SearchWord { get; set; }
    public Guid? ClientId { get; set; }
    public SortedByEnum? SortedBy { get; set; }
    public List<ProjectTypeEnum>? ProjectType { get; set; } = null;
    public bool IsFixed { get; set; } = false;
    public bool IsHourly { get; set; } = false;
    public List<ClientInfoEnum>? ClientInfo { get; set; } = null;
    public List<ProjectDurationEnum>? ProjectDuration { get; set; } = null;
    public List<HoursPerWeekEnum>? HoursPerWeek { get; set; } = null;
    public List<Guid>? CountriesId { get; set; } = null;
    public List<Guid>? CategoryIds { get; set; } = null;
    public NumberOfProposalsDto? NumberOfProposals { get; set; } = null;

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
    PreviousClients = 1,
    PaymentVerified = 2
}

